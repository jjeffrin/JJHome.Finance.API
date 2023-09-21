using JJHome.Finance.Models;
using Microsoft.EntityFrameworkCore;

namespace JJHome.Finance.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // NOTE!: ENABLE THE FOLLOWING CODE IN THE CONSTRUCTOR, IF YOU NEED TO DEBUG ONMODELCREATING OR SIMILAR METHODS WHEN RUNNING THE 'UPDATE-DATABASE' COMMAND
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}
        }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Saving> Savings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set table names to be upper case
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entity.GetTableName();
                // GetTableName() returns nullable string, and hence the null check below.
                if (tableName != null)
                {
                    entity.SetTableName(tableName.ToUpper());
                }
            }

            // Set column names to be upper case
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var column in entity.GetProperties())
                {
                    column.SetColumnName(column.GetColumnName().ToUpper());
                }
            }
        }
    }
}
