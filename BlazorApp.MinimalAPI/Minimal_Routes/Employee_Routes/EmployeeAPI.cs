using BlazorApp.MinimalAPI.Services;
using BlazorApp.Shared;
using Microsoft.AspNetCore.Mvc;
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

                return Results.Ok(response);

            })
                .RequireAuthorization()
                .WithTags("Employee");

            // Post
            app.MapPost("api/employee", async ([FromServices] IEmployee employeeService, EmployeeDTO employee) =>
            {
                return Results.Created("api/employees", await employeeService.AddEmployee(employee));
            })
                .RequireAuthorization()
                .WithDisplayName("Employee Post")
                .WithTags("Employee");

            // Get by ID //
            app.MapGet("api/employee/{id}", async ([FromServices] IEmployee employeeService, int id) =>
            {
                var response = await employeeService.GetEmployee(id);

                if (response != null)
                    return Results.Ok(response);
                else
                    return Results.NotFound();
            })
                .RequireAuthorization()
                .WithTags("Employee");

            // Edit 
            app.MapPut("api/employee", async ([FromServices] IEmployee employeeService, EmployeeDTO employee) =>
            {
                return Results.Ok(await employeeService.UpdateEmployee(employee));
            })
                .RequireAuthorization()
                .WithTags("Employee");

            // Delete
            app.MapDelete("api/employee/{id}", async ([FromServices] IEmployee employeeService, int id) =>
            {
                return Results.Ok(await employeeService.DeleteEmployee(id));
            })
                .RequireAuthorization()
                .WithTags("Employee");
        }
    }
}
