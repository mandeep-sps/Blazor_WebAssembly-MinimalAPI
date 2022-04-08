using BlazorApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data.Context
{
    public partial class BlazorDBContext : DbContext
    {
        public BlazorDBContext(DbContextOptions<BlazorDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<DepartmentRole> DepartmentRoles { get; set; } = null!;
        public virtual DbSet<Domain> Domains { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeTask> EmployeeTasks { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Tasks> Tasks { get; set; } = null!;
        public virtual DbSet<TasksStatus> TaskStatuses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable("ApplicationUser");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Domain)
                    .WithMany(p => p.ApplicationUsers)
                    .HasForeignKey(d => d.DomainId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Applicati__Domai__440B1D61");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.HasOne(d => d.Domain)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.DomainId)
                    .HasConstraintName("FK__Departmen__Domai__33D4B598");
            });

            modelBuilder.Entity<DepartmentRole>(entity =>
            {
                entity.ToTable("DepartmentRole");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DepartmentRoles)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Departmen__Depar__3C69FB99");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.DepartmentRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Departmen__RoleI__3D5E1FD2");
            });

            modelBuilder.Entity<Domain>(entity =>
            {
                entity.ToTable("Domain");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(500);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Doj)
                    .HasColumnType("date")
                    .HasColumnName("DOJ");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.EmployeeCode).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(100);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Domain)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DomainId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__Domain__4316F928");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__Id__4222D4EF");
            });

            modelBuilder.Entity<EmployeeTask>(entity =>
            {
                entity.ToTable("EmployeeTask");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeTasks)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeT__Emplo__52593CB8");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.EmployeeTasks)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeT__TaskI__534D60F1");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Domain)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.DomainId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Role__DomainId__38996AB5");
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.ToTable("Tasks");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Domain)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.DomainId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_Domain");
            });

            modelBuilder.Entity<TasksStatus>(entity =>
            {
                entity.ToTable("TasksStatus");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
