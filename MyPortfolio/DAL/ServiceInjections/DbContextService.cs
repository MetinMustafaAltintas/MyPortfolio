using Microsoft.EntityFrameworkCore;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.DAL.ServiceInjections
{
    public static class DbContextService
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services)
        {

            ServiceProvider provider = services.BuildServiceProvider();

            IConfiguration? configuration = provider.GetService<IConfiguration>();

            services.AddDbContextPool<MyPortfolioContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("MyConnection")).UseLazyLoadingProxies());

            return services;
        }
    }
}
