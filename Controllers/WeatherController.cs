using JwtRoleAuthDemo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtRoleAuthDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService _weatherService;
        public WeatherController(IHttpClientFactory factory, WeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetWeather()
        {
            return Ok("Authenticated User Weather Data");
        }

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAdminWeather()
        {
            return Ok("Admin Only Weather Data");
        }

        [HttpGet("user")]
        [Authorize(Roles ="User")]
        public IActionResult GetOnlyUser()
        {
            return Ok("Only User Can Access");
        }

        [HttpGet("weather")]
        public async Task<IActionResult> GetExternalWeather()
        {
            var data = await _weatherService.GetWeather();

            return Ok(data);
        }
    }
}
