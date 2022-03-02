using BlazorApp;
using BlazorApp.Server;
using BlazorApp.Server.Context;
using BlazorApp.Server.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<BlazorDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(BlazorDBContext))));
builder.Services.AddTransient<IRepository, Repository>();
builder.Services.AddTransient<IEmployee, EmployeeService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapEmployeeRoutes();

app.Run();