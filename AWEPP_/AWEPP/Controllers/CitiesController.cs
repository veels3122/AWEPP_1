using AWEPP.Model;
using AWEPP.Modelo;
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

        public CitiesController(ICitiesServices citiesServices)
        {
            _citiesServices = citiesServices;
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
            return NoContent();
        }
    }
}





    
        

