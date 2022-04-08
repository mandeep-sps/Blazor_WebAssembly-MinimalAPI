namespace BlazorApp.Data.Models
{
    public partial class ApplicationUser
    {
        public int Id { get; set; }
        public string Password { get; set; } = null!;
        public string Hash { get; set; } = null!;
        public int Theme { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int DomainId { get; set; }

        public virtual Domain Domain { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
    }
}
