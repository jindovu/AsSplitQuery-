using Demo.Entity;
using Demo.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Mascot.PLM.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection InitSqlDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            static void ConfigureSqlOptions(SqlServerDbContextOptionsBuilder sqlOptions)
            {
                // Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency 
                sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
            };

            services.AddDbContext<LocalDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("SQLConnection"), ConfigureSqlOptions);
            }).AddUnitOfWork<LocalDbContext>();

            return services;
        }
    }
}
