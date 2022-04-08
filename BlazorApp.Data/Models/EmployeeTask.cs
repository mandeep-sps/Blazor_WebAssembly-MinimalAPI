namespace BlazorApp.Data.Models
{
    public partial class EmployeeTask
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int TaskId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Tasks Task { get; set; } = null!;
    }
}
