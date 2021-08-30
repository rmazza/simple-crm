using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Simcrm.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            _logger.LogInformation("Order called {0}", id);
            return Ok(id);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateOrder([FromBody] OrderModel[] order)
        {
            //TODO: return order number
            return Created("create", order);
        }
    }
}
