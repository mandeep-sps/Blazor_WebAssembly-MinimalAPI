namespace BlazorApp.Data.Models
{
    public partial class TasksStatus
    {
        public int Id { get; set; }
        public string StatusName { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
