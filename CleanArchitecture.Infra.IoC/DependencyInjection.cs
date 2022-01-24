using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data;
using CleanArchitecture.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            AddAutoMapper(services);
            return services;
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            //services.AddAutoMapper(typeof());
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddRepositories(services);

            return services;
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                                u => u.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }
    }
}
