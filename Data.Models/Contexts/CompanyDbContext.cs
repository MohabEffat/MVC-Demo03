using Company.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Company.Data.Contexts
{
    public class CompanyDbContext : IdentityDbContext<ApplicationUser>
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer("");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }
    }
}
