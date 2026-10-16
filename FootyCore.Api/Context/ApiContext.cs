using FootyCore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootyCore.Api.Context
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=FootyCoreDb;Trusted_Connection=True; TrustServerCertificate=True;");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers  { get; set; }
    }
}
