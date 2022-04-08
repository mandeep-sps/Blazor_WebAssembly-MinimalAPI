namespace BlazorApp.Data.Models
{
    public partial class DepartmentRole
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int RoleId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}
