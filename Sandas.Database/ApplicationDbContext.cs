using Microsoft.EntityFrameworkCore;
using Sandas.Domain.Models;

namespace Sandas.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
       // public DbSet<CompensationType> CompensationTypes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = SandasDb");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
