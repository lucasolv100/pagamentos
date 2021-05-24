using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Payments.Data;
using Payments.Data.Repositories;
using Payments.Domain.Entities;
using Payments.Domain.Interfaces;
using Payments.Domain.ViewModels;
using Payments.Domain.Workers;

namespace Payments.API.Bootstrap
{
    public static class DependencyInjection
    {
        public static void RegisterCustomServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PaymentsContext>(options =>
				options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IWorker<RegisterAccountVM>, AccountWorker>();
            
        }
    }
}