using BlazorApp.Shared.Utils;

namespace BlazorApp.Server.Models
{
    public class Employee
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public Designation Designation { get; set; }
        
        public Department Department { get; set; }

        public string EmployeeCode { get; set; }

    }   
}
