using BlazorApp.MinimalAPI.Services;
using BlazorApp.Shared;
using Microsoft.AspNetCore.Mvc;
namespace BlazorApp.Server
{
    public static class ApplicationUserAPI
    {
        public static void MapApplicationUserRoutes(this IEndpointRouteBuilder app)
        {

            // Signup Post
            app.MapPost("api/signup", async ([FromServices] IAccount accountService, ApplicationUserDTO user) =>
            {
                return Results.Created("api/signup", await accountService.Signup(user));
            });

            // Signup Post
            app.MapGet("api/accounts", async ([FromServices] IAccount accountService) =>
            {
                return Results.Ok(await accountService.Accounts());
            });

            // login Post
            app.MapPost("api/login", async ([FromServices] IAccount accountService, LoginDTO login) =>
            {
                return await accountService.Login(login) ? Results.Ok() : Results.NotFound();
            });
        }
    }
}