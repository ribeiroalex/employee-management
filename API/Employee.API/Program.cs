using System;
using System.Text.Json.Serialization;
using Employee.Domain.Entities.Validators;
using Employee.Domain.Handlers;
using Employee.Domain.Mapping;
using Employee.Domain.Repositories;
using Employee.Domain.Services;
using Emplyee.Infra.Contexts;
using Emplyee.Infra.Mappings;
using Emplyee.Infra.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
 //       options.UseInMemoryDatabase("Employees"));
options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")),
        optionsLifetime: ServiceLifetime.Scoped);

builder.Services.AddAutoMapper(typeof(EmployeeProfile));
builder.Services.AddTransient<IEmployeeRepository, EmployeRepository>();
builder.Services.AddTransient<IRolePermissionRepository, RolePermissionRepository>();
builder.Services.AddTransient<EmployeeHandler, EmployeeHandler>();
builder.Services.AddTransient<RolePermissionService>();

builder.Services.AddValidatorsFromAssemblyContaining<EmployeeValidator>(ServiceLifetime.Transient);


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseCors(x =>
    x.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
DataContext context = scope.ServiceProvider.GetRequiredService<DataContext>();
context.Database.Migrate();

app.Run();
