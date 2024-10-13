using AWEPP.Modelo;
using AWEPP.Services;
using Microsoft.AspNetCore.Mvc;

namespace AWEPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesServices _citiesServices;

        public CitiesController(ICitiesServices citiesServices)
        {
            _citiesServices = citiesServices;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Cities>>>GetAllCities()
        {
            var cities = await _citiesServices.GetAllCitiesAsync();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Cities>> GetCityById(int id)
        {
            var cities = await _citiesServices.GetCityByIdAsync(id);
            if (cities == null)
            {
                return NotFound();
            }
            return Ok(cities);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Cities>> CreateCity([FromBody] Cities cities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _citiesServices.CreateCityAsync(cities);
                return CreatedAtAction(nameof(GetCityById), new { id = cities.Id }, cities);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCities(int id, [FromBody] Cities cities)
        {
            if (id != cities.Id)
            {
                return BadRequest("El ID en la URL y en el cuerpo de la solicitud no coinciden.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatecity = await _citiesServices.UpdateCityAsync(cities);
            
            if (updatecity == null)
            {
                return NotFound();
            }

            return NoContent();
            }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteCities(int id)
        {
            if (id <= 0)
            {
                return NotFound("el numero debe ser un numero positivo");
            }
            await _citiesServices.SoftDeleteCityAsync(id);
            return NoContent();
        }
    }
}