using BlazorApp.Shared;

namespace BlazorApp.MinimalAPI.Services
{
    public interface IAccount
    {
        Task<ServiceResult<bool>> Signup(ApplicationUserRequest applicationUser);

        Task<ServiceResult<LoginResponse>> Login(LoginDTO login, ConfigurationManager configuration);

        Task<ServiceResult<List<ApplicationUserResponse>>> Accounts();

        Task<ServiceResult<ApplicationUserResponse>> UserInfo(int id);
    }
}
