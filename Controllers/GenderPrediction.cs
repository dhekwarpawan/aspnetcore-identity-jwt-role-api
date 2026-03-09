using JwtRoleAuthDemo.Models;
using JwtRoleAuthDemo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtRoleAuthDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderPrediction : ControllerBase
    {
        private readonly GenderPredictionService _genderPredictionservice;
        private readonly MyTestService _MyTestService;
        public GenderPrediction(GenderPredictionService genderPredictionservice, MyTestService MyTestService)
        {
            _genderPredictionservice = genderPredictionservice; _MyTestService = MyTestService;
        }
        [HttpGet("name")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GenderPredictionFn(string name)
        {
            var result = await _genderPredictionservice.PredictGender(name);

            return Ok(result);

        }

        [HttpPost("expiry")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CheckExpiry(CheckExpiryPostModel LicenseCode)
        {
            var result = await _MyTestService.GetExpiry(LicenseCode);

            return Ok(result);

        }
    }
}
