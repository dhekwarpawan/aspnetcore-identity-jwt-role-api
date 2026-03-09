namespace JwtRoleAuthDemo.Services
{
    public class GenderPredictionService
    {
        private readonly HttpClient _httpClient;

        public GenderPredictionService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient("genderApi");           
        }
        public async Task<string> PredictGender(string name)
        {

            var response = await _httpClient.GetAsync($"?name={name}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
