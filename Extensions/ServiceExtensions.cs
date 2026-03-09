using JwtRoleAuthDemo.Services;

namespace JwtRoleAuthDemo.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddExternalApiClients(this IServiceCollection services)
        {
            services.AddHttpClient<WeatherService>(client =>
            {
                client.BaseAddress = new Uri("https://api.agify.io/");
            });

            services.AddHttpClient<GenderPredictionService>("genderApi", client =>
            {
                client.BaseAddress = new Uri("https://api.genderize.io/");
            });

            services.AddHttpClient<GenderPredictionService>("GetCheckExpiry", client =>
            {
                client.BaseAddress = new Uri("https://npav.net/UserInfoMobileNew/");
            });
        }
    }
}
