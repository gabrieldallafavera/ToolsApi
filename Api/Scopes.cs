using Api.Services.Services;

namespace Api
{
    public static class Scopes
    {
        public static void OnScopeCreating(IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
