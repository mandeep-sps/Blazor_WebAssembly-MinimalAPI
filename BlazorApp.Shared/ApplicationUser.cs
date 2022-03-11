using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Shared
{
    public class ApplicationUserDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string ContactNo { get; set; }

        public string Password { get; set; }

        public string RepeatPassword { get; set; }
    }

    public class LoginDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string CnfrmPassword { get; set; }
    }
}
