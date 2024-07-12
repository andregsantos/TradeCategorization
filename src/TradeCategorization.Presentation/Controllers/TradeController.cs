using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TradeCategorization.Domain.Entities;
using TradeCategorization.Application;

namespace TradeCategorization.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TradeController : ControllerBase
    {
        private readonly ICategorizeTradesUseCase _categorizeTradesUseCase;

        public TradeController(ICategorizeTradesUseCase categorizeTradesUseCase)
        {
            _categorizeTradesUseCase = categorizeTradesUseCase;
        }

        [HttpPost("categorize")]
        [Authorize]
        public IActionResult CategorizeTrades([FromBody] List<Trade> trades)
        {
            var categories = _categorizeTradesUseCase.Execute(trades);
            return Ok(categories);
        }
    }
}
