namespace JwtRoleAuthDemo.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("https://api.open-meteo.com/");
        }

        public async Task<string> GetWeather()
        {
            var response = await _httpClient.GetAsync("v1/forecast?latitude=19.07&longitude=72.87&current_weather=true");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
