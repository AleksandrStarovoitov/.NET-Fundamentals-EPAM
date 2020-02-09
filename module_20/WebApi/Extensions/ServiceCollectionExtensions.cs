using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDbContextExt<TContext>(this IServiceCollection services, string connectionString) where TContext : DbContext
        {
            services.AddDbContextPool<TContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
