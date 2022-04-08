using BlazorApp.Data;
using BlazorApp.Data.Context;
using BlazorApp.MinimalAPI.Services;
using BlazorApp.Server;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                        builder =>
                        {
                            builder.WithOrigins("*")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                        });
            });

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = Configuration["Jwt:Issuer"],
                            ValidAudience = Configuration["Jwt:Issuer"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"]))
                        };
                    });

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Blazor App", Version = "v1", Description = "An ASP.NET Core Web API for managing Blazor App." });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id="Bearer",
                            }
                        },
                        new string[]{}
                    }
                });
});

builder.Services.AddDbContextPool<BlazorDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(BlazorDBContext))));

builder.Services.AddTransient<IRepository, Repository>();

builder.Services.AddTransient<IEmployee, EmployeeService>();

builder.Services.AddTransient<IAccount, AccountService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.DocumentTitle = ".Net 6 Minimal API");

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.MapEmployeeRoutes();

app.MapApplicationUserRoutes(Configuration);

app.Run();