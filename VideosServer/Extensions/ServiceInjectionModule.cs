
using Domain.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace VideosServer.Extensions
{
    public static class ServiceInjectionModule
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // configuration for access to database
            services.AddDbContext<VideoDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("Domain"));
            });
            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => new OpenApiInfo
            {
                Version = "v1",
                Title = "Videos streaming API",
                Description = "Application for managing video data",
            });

            return services;
        }
    }
}
