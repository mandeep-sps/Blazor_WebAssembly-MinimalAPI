using BlazorApp.MinimalAPI.Models;
using BlazorApp.Shared;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq.Expressions;

namespace BlazorApp.MinimalAPI.Services
{
    public class AccountService : IAccount
    {
        private readonly IRepository repository;

        public AccountService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Signup(ApplicationUserDTO applicationUser)
        {
            try
            {
                if (await repository.FindBy<ApplicationUser>(x => x.Email == applicationUser.Email).AnyAsync())
                {
                    return "Email already exist";
                }

                if (await repository.FindBy<ApplicationUser>(x => x.ContactNo == applicationUser.ContactNo).AnyAsync())
                {
                    return "Contact number already exist";
                }


                ApplicationUser model = new()
                {
                    Name = applicationUser.Name,
                    Email = applicationUser.Email,
                    ContactNo = applicationUser.ContactNo,
                    Password = applicationUser.Password,
                };

                return await repository.AddAsync(model) > 0 ? "Account has been created" : "There is some issue";
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<bool> Login(LoginDTO login)
        {
            try
            {
                var data = await repository.FindBy<ApplicationUser>(x => x.Email == login.Email).FirstOrDefaultAsync();

                if (data != null)
                {
                    if (data.Password.Equals(login.Password))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ApplicationUserDTO>> Accounts()
        {
            try
            {
                var accounts = await repository.GetAll<ApplicationUser>().Select(UserExpression()).OrderBy(x => x.Name).ToListAsync();

                return accounts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Private Expression for Code repete
        /// </summary>
        /// <returns></returns>
        private static Expression<Func<ApplicationUser, ApplicationUserDTO>> UserExpression()
        {
            return x => new ApplicationUserDTO
            {
                ContactNo = x.ContactNo,
                Email = x.Email,
                Id = x.Id,
                Name = x.Name,
                Password = x.Password,
            };
        }
    }
}
