using BlazorApp.MinimalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.MinimalAPI.Context
{
    public class BlazorDBContext : DbContext
    {
        public BlazorDBContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var foreignKey in builder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.Entity<Employee>().HasData(
              new Employee { Id = 1, Name = "Paramjeet Singh", EmployeeCode = "SP-1001", Email = "param@sp.com", Department = Shared.Utils.Department.MED, Designation = Shared.Utils.Designation.PM },
              new Employee { Id = 2, Name = "Mandeep Singh", EmployeeCode = "SP-1002", Email = "mandeep@sp.com", Department = Shared.Utils.Department.MED, Designation = Shared.Utils.Designation.Architect }
            );

            builder.Entity<ApplicationUser>().HasData(
              new ApplicationUser { Id = 1, Name = "Admin SP", Email = "admin@sp.com", ContactNo = "9009123456", Password = "admin@12345" }
            );
        }


        public DbSet<Employee> Employees_Blazor { get; set; }
        public DbSet<ApplicationUser> ApplicationUser_Blazor { get; set; }
    }
}
