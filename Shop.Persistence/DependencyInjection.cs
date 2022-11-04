using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Shop.Application.Interfaces;

namespace Shop.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
           services, IConfiguration configuration)
        {
            var shopconnection = configuration.GetConnectionString("ShopContextConnection");
            services.AddDbContext<ShopContext>(options =>
            {
                options.UseSqlServer(shopconnection);
            });
            services.AddScoped<IShopDbContext>(provider =>
                provider.GetService<ShopContext>());
            return services;
        }
    }
}
