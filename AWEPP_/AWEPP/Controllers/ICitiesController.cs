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
        public async Task<ActionResult<IEnumerable<Cities>>>GetAllCities()
        {
            var cities = await _citiesServices.GetAllCitiesAsync();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cities>> GetCityById(int id)
        {
            var city = await _citiesServices.GetCityByIdAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpPost]
        public async Task<ActionResult<Cities>> CreateCity([FromBody] Cities cities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newCity = await _citiesServices.CreateCityAsync(cities);
                return CreatedAtAction(nameof(GetCityById), new { id = newCity.Id }, newCity);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCity(int id, [FromBody] Cities cities)
        {
            if (id != cities.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _citiesServices.UpdateCityAsync(cities);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteCity(int id)
        {
            await _citiesServices.SoftDeleteCityAsync(id);
            return NoContent();
        }
    }
}