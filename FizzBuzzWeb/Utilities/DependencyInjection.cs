using FizzBuzzWeb.Services;

namespace FizzBuzzWeb.Utilities
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProjectService(this
        IServiceCollection services)
        {
            services.AddTransient<IFormService, FormService>();
            services.AddTransient<IFormRepository, FormRepository>();
            services.AddTransient<IUserService, UserService>();
            return services;
        }
    }
}
