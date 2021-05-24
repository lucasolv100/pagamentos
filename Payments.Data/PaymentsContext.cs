using System;
using Microsoft.EntityFrameworkCore;
using Payments.Data.Configs;
using Payments.Domain.Entities;

namespace Payments.Data
{
    public class PaymentsContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountMovement> Movements { get; set; }

        public PaymentsContext(DbContextOptions<PaymentsContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new AccountConfig());
			modelBuilder.ApplyConfiguration(new AccountMovementConfig());
		}
        
    }
}
