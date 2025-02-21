using System.Collections.Generic;

namespace MyGameShopApi.Controllers
{
    public interface IWeatherForcastService
    {
        IEnumerable<WeatherForecast> Get(int resultCounter, int tempMin, int tempMax);
    }
}