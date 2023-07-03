using JJHome.Finance.Models;
using Microsoft.EntityFrameworkCore;

namespace JJHome.Finance.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Organization> Organizations { get; set; }
    }
}
