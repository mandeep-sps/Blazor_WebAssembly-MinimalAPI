namespace BlazorApp.Data.Models
{
    public partial class Domain
    {
        public Domain()
        {
            ApplicationUsers = new HashSet<ApplicationUser>();
            Departments = new HashSet<Department>();
            Employees = new HashSet<Employee>();
            Roles = new HashSet<Role>();
            Tasks = new HashSet<Tasks>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string About { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
