using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using MyGameShopApi.Controllers;

namespace MyGameShopApi
{
    public class WeatherForcastService : IWeatherForcastService
    {
        private static readonly string[] Summaries = new[]
     {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<WeatherForecast> Get(int resultCounter, int tempMin, int tempMax)
        {
            var rng = new Random();
            return Enumerable.Range(1, resultCounter).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(tempMin, tempMax),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
