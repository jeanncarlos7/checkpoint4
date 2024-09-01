using checkpoint4.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace checkpoint4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        private readonly IConversionRate _conversionRateService;

        public ExchangeController(IConversionRate conversionRateService)
        {
            _conversionRateService = conversionRateService;
        }

        [HttpGet("usd-to-brl")]
        public async Task<IActionResult> GetUsdToBrl()
        {
            var rate = await _conversionRateService.GetUsdToBrlRateAsync();
            return Ok(new { USD_To_BRL = rate });
        }
    }
}
