using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace DataAccess.Contexts
{
    public class BaseNArchitectureContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public BaseNArchitectureContext(DbContextOptions<BaseNArchitectureContext> options,IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }
       
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
 }
