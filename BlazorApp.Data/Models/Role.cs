namespace BlazorApp.Data.Models
{
    public partial class Role
    {
        public Role()
        {
            DepartmentRoles = new HashSet<DepartmentRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int DomainId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

        public virtual Domain Domain { get; set; } = null!;
        public virtual ICollection<DepartmentRole> DepartmentRoles { get; set; }
    }
}
