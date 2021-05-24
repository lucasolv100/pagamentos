using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Payments.Data;

namespace Payments.API.Bootstrap
{
    public static class DependencyInjection
    {
        public static void RegisterCustomServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PaymentsContext>(options =>
				options.UseSqlServer(connectionString));
        }
    }
}