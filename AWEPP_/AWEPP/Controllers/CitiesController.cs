﻿using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Models;
using AWEPP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWEPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesServices _citiesServices;
        private readonly AuditService _auditLogService;
        public CitiesController(ICitiesServices citiesServices,IAuditService auditService)
        {
            _citiesServices = citiesServices;
            _auditLogService = (AuditService?)auditService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Cities>>> GetAllCities()
        {
            var Cities = await _citiesServices.GetAllCitiesAsync();
            return Ok(Cities);
        }


        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Cities>> GetCitiesById(int Id)
        {
            var Cities = await _citiesServices.GetCitiesByIdAsync(Id);
            if (Cities == null)
                return NotFound();
            return Ok(Cities);

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateCities([FromBody] Cities Cities)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _citiesServices.CreateCitiesAsync(Cities);
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "CreateCities",
                TableName = "Cities",
                RecordId = Cities.Id.ToString(),
                Changes = $"City {Cities.City} creado.",
                UserName = "Admin",
                Date = DateTime.UtcNow.AddHours(-5)
            });
            return CreatedAtAction(nameof(GetCitiesById), new { id = Cities.Id }, Cities);

        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateCities(int Id, [FromBody] Cities Cities)
        {
            if (Id != Cities.Id)
                return BadRequest();
            var existingCities = await _citiesServices.GetCitiesByIdAsync(Id);
            if (existingCities == null)
                return NoContent();

            await _citiesServices.UpdateCitiesAsync(Cities);
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "UpdateCities",
                TableName = "Cities",
                RecordId = Cities.Id.ToString(),
                Changes = $"City {Cities.City} actualizado.",
                UserName = "Admin",
                Date = DateTime.UtcNow.AddHours(-5)
            });
            return NoContent();

        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SoftDeleteBank(int Id)
        {
            var Cities = await _citiesServices.GetCitiesByIdAsync(Id);
            if (Cities == null)
                return NotFound();

            await _citiesServices.SoftDeleteCitiesAsync(Id);
            await _auditLogService.LogEventAsync(new AuditLog
            {
                Action = "softCities",
                TableName = "Cities",
                RecordId = Cities.Id.ToString(),
                Changes = $"City {Cities.City} marca como eliminado.",
                UserName = "Admin",
                Date = DateTime.UtcNow.AddHours(-5)
            });
            return NoContent();
        }
    }
}





    
        

