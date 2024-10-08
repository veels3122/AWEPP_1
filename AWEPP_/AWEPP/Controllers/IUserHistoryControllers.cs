﻿using AWEPP.Model;
using AWEPP.Services;
using Microsoft.AspNetCore.Mvc;

namespace AWEPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserHistoriesController : ControllerBase
    {
        private readonly IUserHistoryServices _userHistoryService;

        public UserHistoriesController(IUserHistoryServices userHistoryService)
        {
            _userHistoryService = userHistoryService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UserHistory>>> GetAllUserHistories()
        {
            var userHistories = await _userHistoryService.GetAllUserHistoriesAsync();
            return Ok(userHistories);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserHistory>> GetUserHistoryById(int id)
        {
            var userHistory = await _userHistoryService.GetUserHistoryByIdAsync(id);
            if (userHistory == null)
            {
                return NotFound();
            }
            return Ok(userHistory);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserHistory>> CreateUserHistory([FromBody] UserHistory userHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newUserHistory = await _userHistoryService.CreateUserHistoryAsync(userHistory);
            return CreatedAtAction(nameof(GetUserHistoryById), new { id = newUserHistory.Id }, newUserHistory);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUserHistory(int id, [FromBody] UserHistory userHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedUserHistory = await _userHistoryService.UpdateUserHistoryAsync(userHistory);
            if (updatedUserHistory == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteUserHistory(int id)
        {
            await _userHistoryService.SoftDeleteUserHistoryAsync(id);
            return NoContent();
        }
    }
}