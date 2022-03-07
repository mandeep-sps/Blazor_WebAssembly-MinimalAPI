using BlazorApp.Shared.Utils;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Shared
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public Designation? Designation { get; set; }

        [Required]
        public Department? Department { get; set; }

        [Display(Name = "Employee Code")]
        public string EmployeeCode { get; set; }

    }
}