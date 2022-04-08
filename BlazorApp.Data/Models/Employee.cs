namespace BlazorApp.Data.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeTasks = new HashSet<EmployeeTask>();
        }

        public int Id { get; set; }
        public int DomainId { get; set; }
        public string Name { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string EmployeeCode { get; set; } = null!;
        public string Location { get; set; }
        public DateTime? Doj { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Domain Domain { get; set; } = null!;
        public virtual ApplicationUser IdNavigation { get; set; } = null!;
        public virtual ICollection<EmployeeTask> EmployeeTasks { get; set; }
    }
}
