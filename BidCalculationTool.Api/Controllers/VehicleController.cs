using BidCalculationTool.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BidCalculationTool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController(ICalculationService calculationService) : Controller
    {
        [HttpGet("/calculate-fees/{basePrice}/{type}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CalculateFees(decimal basePrice, int type)
        {
            if (basePrice < 0) {
                return BadRequest("Base price must be greater than 0");
            }
            var result = calculationService.CalculateVehicleFees(basePrice, type);
            return Ok(result);
        }

    }
}
