using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Price.Engine;

namespace Parking.Cost.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PricingController : ControllerBase
    {
        private readonly ILogger<PricingController> _logger;
        private readonly IPriceEngine _engine;

        public PricingController(ILogger<PricingController> logger, IPriceEngine engine)
        {
            _logger = logger;
            _engine = engine;
        }

        [HttpGet]
        public IActionResult Get(DateTime enter, DateTime exit)
        {
            var request = new PriceRequest(enter, exit);
            _logger.LogInformation("Calcualte price for period {Enter}-{Exit} ", request.Enter, request.Exit);
           var result = _engine.Evaluate(request);
           if (result == 0)
           {
               return BadRequest();
           }

           return Ok(result);
        }
    }
}
