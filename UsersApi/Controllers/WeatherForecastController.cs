using Infrastructure.Caching;
using Infrastructure.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using UsersApi.ViewModel;

namespace UsersApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogging _fileLogger;

        public WeatherForecastController(IFactory<IFileLoggingFactory> factory)
        {
            _fileLogger = factory.Create().GetLogger();
        }

        [HttpPost]
        public IActionResult SetWeather([FromQuery]string city, [FromQuery] double temp)
        {
            InMemoryCache.Instance.SetValue(city, temp);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetWeather([FromQuery] string city)
        {
            var temp = InMemoryCache.Instance.GetValue<double>(city);
            if(temp is default(double))
            {
                return NotFound();
            }
            return Ok(temp);
        }
    }
}
