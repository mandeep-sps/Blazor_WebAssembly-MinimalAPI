using BlazorApp.Shared;

namespace BlazorApp.MinimalAPI.Services
{
    public interface IAccount
    {
        Task<string> Signup(ApplicationUserDTO applicationUser);

        Task<bool> Login(LoginDTO login);

        Task<List<ApplicationUserDTO>> Accounts( );
    }
}
