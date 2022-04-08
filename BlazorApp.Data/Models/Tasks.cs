using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Data.Models
{
    public partial class Tasks
    {
        public Tasks()
        {
            EmployeeTasks = new HashSet<EmployeeTask>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Status { get; set; }
        public string Description { get; set; } = null!;
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int DomainId { get; set; }

        public virtual Domain Domain { get; set; } = null!;
        public virtual ICollection<EmployeeTask> EmployeeTasks { get; set; }
    }
}
