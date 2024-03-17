using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace meteoAPI
{
    public class WeatherService
    {
        private readonly HttpClient _httpsClient;
        private readonly string _apiKey = "60009e115680a2db58f335b498037922";

        public WeatherService(HttpClient httpClient)
        {
            _httpsClient = httpClient;
        }

        public async Task<WeatherData> GetWeatherAsync(string city)
        {
            var response = await _httpsClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric");
            response.EnsureSuccessStatusCode();

            var weatherData = await response.Content.ReadFromJsonAsync<WeatherData>();
            return weatherData;
        }
    }

    public class WeatherData
    {
        public MainData Main { get; set; }
        public Weather[] Weather { get; set; }
    }

    public class MainData
    {
        public float Temp { get; set; }
    }

    public class Weather
    {
        public string Description { get; set; }
    }
}

