using Microsoft.EntityFrameworkCore;
using CompanyTask.Models;

namespace CompanyTask.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> products { get; set; }

    }
}
