namespace BlazorApp.Data.Models
{
    public interface IAudit
    {
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }

    public partial class Department : IAudit { }
    public partial class ApplicationUser : IAudit { }
    public partial class DepartmentRole : IAudit { }
    public partial class Domain : IAudit { }
    public partial class Employee : IAudit { }
    public partial class EmployeeTask : IAudit { }
    public partial class TasksStatus : IAudit { }
    public partial class Role : IAudit { }
    public partial class Tasks : IAudit { }
}
