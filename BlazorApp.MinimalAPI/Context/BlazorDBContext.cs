using BlazorApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Server.Context
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
        }


        public DbSet<Employee> Employees_Blazor { get; set; }
    }
}
