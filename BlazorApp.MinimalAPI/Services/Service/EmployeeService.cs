using BlazorApp.Server.Models;
using BlazorApp.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorApp.Server.Services
{
    public class EmployeeService : IEmployee
    {
        private readonly IRepository repository;

        public EmployeeService(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task<bool> AddEmployee(EmployeeDTO employee)
        {
            try
            {
                Employee model = new()
                {
                    Name = employee.Name,
                    Email = employee.Email,
                    Department = employee.Department,
                    Designation = employee.Designation,
                    EmployeeCode = employee.EmployeeCode,
                };

                return await repository.AddAsync(model) > 0;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            try
            {
                var employees = await repository.GetAll<Employee>().Select(EmployeeExpression()).OrderBy(x => x.Name).ToListAsync();

                return employees;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<EmployeeDTO> GetEmployee(int id)
        {
            try
            {
                var employee = await repository.FindBy<Employee>(x => x.Id == id).Select(EmployeeExpression()).FirstOrDefaultAsync();

                return employee;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        /// <summary>
        /// Private Expression for Code repete
        /// </summary>
        /// <returns></returns>
        private static Expression<Func<Employee, EmployeeDTO>> EmployeeExpression()
        {
            return x => new EmployeeDTO
            {
                Department = x.Department,
                Designation = x.Designation,
                Email = x.Email,
                EmployeeCode = x.EmployeeCode,
                Id = x.Id,
                Name = x.Name,
            };
        }

        public async Task<bool> UpdateEmployee(EmployeeDTO employee)
        {
            try
            {
                var model = repository.GetById<Employee>(employee.Id);

                if (model != null)
                {
                    model.Name = employee.Name;
                    model.Email = employee.Email;
                    model.Department = employee.Department;
                    model.Designation = employee.Designation;
                    model.EmployeeCode = employee.EmployeeCode;

                    return await repository.UpdateAsync(model) > 0;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            try
            {
                var model = repository.GetById<Employee>(id);
                if (model != null)
                    return await repository.DeleteAsync(model) > 0;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
