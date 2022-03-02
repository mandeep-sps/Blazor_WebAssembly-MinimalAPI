using BlazorApp.Server.Models;
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
        }


        public DbSet<Employee> Employees { get; set; }
    }
}
