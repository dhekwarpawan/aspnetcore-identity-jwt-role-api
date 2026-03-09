using JwtRoleAuthDemo.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace JwtRoleAuthDemo.Services
{
    public class MyTestService
    {
        private readonly HttpClient _httpClient;
        public MyTestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> GetExpiry(CheckExpiryPostModel LicenseCode) 
        {
            var result = await _httpClient.PostAsJsonAsync("https://npav.net/UserInfoMobileNew/api/Fraudprotector/check_expiry", LicenseCode);
            return new Response
            {
                status = result.IsSuccessStatusCode ? "success" : "error",
                msg = result.IsSuccessStatusCode ? "Request successful" : "Request failed",
                res = await result.Content.ReadAsStringAsync()
            };
        }

    }


    public class Response
    {
        public string status { get; set; }
        public string msg { get; set; }
        public string res { get; set; }
    }
}
