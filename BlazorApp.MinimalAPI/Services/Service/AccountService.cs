using BlazorApp.Data;
using BlazorApp.MinimalAPI.Models;
using BlazorApp.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;

namespace BlazorApp.MinimalAPI.Services
{
    public class AccountService : IAccount
    {
        private readonly IRepository repository;

        public AccountService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ServiceResult<bool>> Signup(ApplicationUserRequest applicationUser)
        {
            try
            {
                if (await repository.FindBy<ApplicationUser>(x => x.Email == applicationUser.Email).AnyAsync())
                {
                    return new ServiceResult<bool>(false, "Email already exist", true);
                }

                if (await repository.FindBy<ApplicationUser>(x => x.ContactNo == applicationUser.ContactNo).AnyAsync())
                {
                    return new ServiceResult<bool>(false, "Contact number already exist", true);
                }


                ApplicationUser model = new()
                {
                    Name = applicationUser.Name,
                    Email = applicationUser.Email,
                    ContactNo = applicationUser.ContactNo,
                    Password = applicationUser.Password,
                };

                return new ServiceResult<bool>(await repository.AddAsync(model) > 0, "Account has been created");
            }
            catch (Exception ex)
            {
                return new ServiceResult<bool>(ex, ex.Message);
            }
        }


        public async Task<ServiceResult<LoginResponse>> Login(LoginDTO login, ConfigurationManager configuration)
        {
            try
            {
                var data = await repository.FindBy<ApplicationUser>(x => x.Email == login.Email).FirstOrDefaultAsync();

                if (data != null)
                {
                    if (data.Password.Equals(login.Password))
                    {
                        LoginResponse response = new()
                        {
                            Id = data.Id,
                            ContactNo = data.ContactNo,
                            Email = login.Email,
                            Name = data.Name,
                            Password = login.Password,
                            Token = GenerateJSONWebToken(data, configuration)
                        };

                        return new ServiceResult<LoginResponse>(response, "Logged in successfully");
                    }
                }

                return new ServiceResult<LoginResponse>(null, "Invalid credentials", true);
            }
            catch (Exception ex)
            {
                return new ServiceResult<LoginResponse>(ex, ex.Message);
            }
        }

        public async Task<ServiceResult<List<ApplicationUserResponse>>> Accounts()
        {
            try
            {
                var accounts = await repository.GetAll<ApplicationUser>().Select(UserExpression()).OrderBy(x => x.Name).ToListAsync();

                return new ServiceResult<List<ApplicationUserResponse>>(accounts, $"{accounts.Count} Accounts found");
            }
            catch (Exception ex)
            {
                return new ServiceResult<List<ApplicationUserResponse>>(ex, ex.Message);
            }
        }

        public async Task<ServiceResult<ApplicationUserResponse>> UserInfo(int id)
        {
            try
            {
                var userInfo = await repository.FindBy<ApplicationUser>(x => x.Id == id).Select(UserExpression()).FirstOrDefaultAsync();

                return new ServiceResult<ApplicationUserResponse>(userInfo, $"User Info");
            }
            catch (Exception ex)
            {
                return new ServiceResult<ApplicationUserResponse>(ex, ex.Message);
            }
        }

        /// <summary>
        /// Private Expression for Code repete
        /// </summary>
        /// <returns></returns>
        private static Expression<Func<ApplicationUser, ApplicationUserResponse>> UserExpression()
        {
            return x => new ApplicationUserResponse
            {
                ContactNo = x.ContactNo,
                Email = x.Email,
                Id = x.Id,
                Name = x.Name,
                Password = x.Password,
            };
        }

        private string GenerateJSONWebToken(ApplicationUser userInfo, ConfigurationManager configuration)
        {
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
                  {
                        new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", userInfo.Id.ToString()),
                        new Claim("Email", userInfo.Email),
                        new Claim("Contact", userInfo.ContactNo),
                        new Claim("Name", userInfo.Name)
                    };
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Issuer"],
                claims, expires: DateTime.Now.AddHours(2), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
