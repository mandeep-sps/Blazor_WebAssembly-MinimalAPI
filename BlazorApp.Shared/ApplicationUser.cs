namespace BlazorApp.Shared
{
    public class ApplicationUserResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string ContactNo { get; set; }

        public string Password { get; set; }


    }

    public class ApplicationUserRequest : ApplicationUserResponse
    {
        public string RepeatPassword { get; set; }
    }

    public class LoginDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }

    }

    public class LoginResponse : ApplicationUserResponse
    {
        public string Token { get; set; }

    }
}
