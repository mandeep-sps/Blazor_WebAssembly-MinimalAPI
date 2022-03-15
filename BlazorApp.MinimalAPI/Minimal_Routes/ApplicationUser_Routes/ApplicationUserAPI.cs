using BlazorApp.MinimalAPI.Services;
using BlazorApp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server
{
    public static class ApplicationUserAPI
    {
        public static void MapApplicationUserRoutes(this IEndpointRouteBuilder app, ConfigurationManager configuration)
        {
            // Signup Post
            app.MapPost("api/signup", async ([FromServices] IAccount accountService, ApplicationUserRequest user) =>
            {
                var response = await accountService.Signup(user);
                var apiResponse = new ApiResponseModel(response.HasValidationError ? System.Net.HttpStatusCode.Conflict : System.Net.HttpStatusCode.OK, response.Message, response.Exception, response.Data);
                return Results.Json(apiResponse);
            });

            // Signup Post
            app.MapGet("api/accounts", [Authorize] async ([FromServices] IAccount accountService) =>
             {
                 var response = await accountService.Accounts();
                 var apiResponse = new ApiResponseModel(response.HasValidationError ? System.Net.HttpStatusCode.Conflict : System.Net.HttpStatusCode.OK, response.Message, response.Exception, response.Data);
                 return Results.Json(apiResponse);
             });

            app.MapGet("api/userinfo/{id}", async ([FromServices] IAccount accountService, int id) =>
            {
                var response = await accountService.UserInfo(id);
                var apiResponse = new ApiResponseModel(response.HasValidationError ? System.Net.HttpStatusCode.Conflict : System.Net.HttpStatusCode.OK, response.Message, response.Exception, response.Data);
                return Results.Json(apiResponse);
            });

            // login Post
            app.MapPost("api/login", async ([FromServices] IAccount accountService, LoginDTO login) =>
            {
                var response = await accountService.Login(login, configuration);
                var apiResponse = new ApiResponseModel(response.HasValidationError ? System.Net.HttpStatusCode.Conflict : System.Net.HttpStatusCode.OK, response.Message, response.Exception, response.Data);
                return Results.Json(apiResponse);
            });
        }


    }
}