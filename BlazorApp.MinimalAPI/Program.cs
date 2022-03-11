using BlazorApp;
using BlazorApp.MinimalAPI.Context;
using BlazorApp.MinimalAPI.Services;
using BlazorApp.Server;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsPolicy", opt => opt
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<BlazorDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(BlazorDBContext))));
builder.Services.AddTransient<IRepository, Repository>();
builder.Services.AddTransient<IEmployee, EmployeeService>();
builder.Services.AddTransient<IAccount, AccountService>();
var app = builder.Build();

app.UseCors("CorsPolicy");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapEmployeeRoutes();
app.MapApplicationUserRoutes();

app.Run();