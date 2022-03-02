using BlazorApp.Server.Services;
using Microsoft.AspNetCore.Mvc;
using BlazorApp.Shared;
namespace BlazorApp.Server
{
    public static class EmployeeAPI
    {

        public static void MapEmployeeRoutes(this IEndpointRouteBuilder app)
        {
            // Get
            app.MapGet("api/employees", async ([FromServices] IEmployee employeeService) =>
            {
                var response = await employeeService.GetEmployees();

                if (response.Any())
                    return Results.Ok(response);
                else
                    return Results.NotFound();
            });

            // Post
            app.MapPost("api/employee", async ([FromServices] IEmployee employeeService, EmployeeDTO employee) =>
            {
                return Results.Created("api/employees", await employeeService.AddEmployee(employee));
            });

            // Get by ID //
            app.MapGet("api/employee/{id}", async ([FromServices] IEmployee employeeService, int id) =>
            {
                var response = await employeeService.GetEmployee(id);

                if (response != null)
                    return Results.Ok(response);
                else
                    return Results.NotFound();
            });

            // Edit 
            app.MapPut("api/employee", async ([FromServices] IEmployee employeeService, EmployeeDTO employee) =>
            {
                return Results.Ok(await employeeService.UpdateEmployee(employee));
            });

            // Delete
            app.MapDelete("api/employee/{id}", async ([FromServices] IEmployee employeeService, int id) =>
            {
                return Results.Ok(await employeeService.DeleteEmployee(id));
            });
        }
    }
}
