using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static Core.Models;

namespace Server.Controllers
{
  [ApiController]
    [Route("api/[controller]")]
    [EnableCors(Startup.OpenCORS)]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching",
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public WeatherForecast Get()
        {
            var rng = new Random();
            return new WeatherForecast(
                date: DateTime.Now,
                summary: Summaries[rng.Next(Summaries.Length)],
                temperatureC: (double)rng.Next(-20, 55)
            );
        }
    }
}
