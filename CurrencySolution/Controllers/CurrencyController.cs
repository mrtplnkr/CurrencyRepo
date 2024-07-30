using Application.Handlers.GetCurrencies;
using CurrencyApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CurrencySolution.Controllers
{
    [Route("[controller]")]
    public class CurrencyController : BaseController
    {
        private readonly ILogger<CurrencyController> _logger;

        public CurrencyController(ILogger<CurrencyController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery]GetCurrencyRequest query)
        {
            var res = await Mediator.Send(query);

            return Ok(res);
        }
    }
}
