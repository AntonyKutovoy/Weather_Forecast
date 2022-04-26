namespace Weather_Forecast.WebApi.Models
{
    public class WeatherForecast : Weather
    {
        public long ExactDate { get; set; }
        public string Date { get; set; }
    }
}
