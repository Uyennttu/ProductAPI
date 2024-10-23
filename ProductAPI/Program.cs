using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductAPI.Data;
using ProductAPI.Interfaces;
using ProductAPI.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductAPIContext") ?? throw new InvalidOperationException("Connection string 'ProductAPIContext' not found.")));
builder.Services.AddScoped<IEmployee, EmployeeService>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
