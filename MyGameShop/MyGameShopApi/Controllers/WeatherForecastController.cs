using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyGameShopApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForcastService service;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForcastService service)
        {
            _logger = logger;
            this.service = service;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var resutl = service.Get();
        //    return resutl;
        //}

        //[HttpGet("currentDay/{max}")]
        //public IEnumerable<WeatherForecast> Get2([FromQuery]int take, [FromRoute]int max)
        //{
        //    var resutl = service.Get();
        //    return resutl;
        //}

        [HttpPost]
        public ActionResult<string> Hello([FromBody]string name)
        {
            //HttpContext.Response.StatusCode = 401;
            //return $"Hello {name}";
            //return StatusCode(401, $"Hello {name}");
            return NotFound($"Hello {name}");
        }

        [HttpPost("generate")]
        public ActionResult<IEnumerable<WeatherForecast>> NewMethod([FromQuery] int resultCounter, [FromBody]int minTemp)
        {
            int maxTemp = 30;
            if (resultCounter < 0 || minTemp > maxTemp)
            {
                return StatusCode(400, "Incorect data inserted");
            }
            var resutl = service.Get(resultCounter, minTemp, maxTemp);
            return StatusCode(200, resutl);
        }
    }
}
