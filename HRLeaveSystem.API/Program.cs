using HRLeaveSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using FluentValidation.AspNetCore;
using System.Reflection;
using HRLeaveSystem.Application.Interfaces;
using HRLeaveSystem.Application.Services;
using HRLeaveSystem.Application.Repositories;
using HRLeaveSystem.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

// 1. Serilog
builder.Host.UseSerilog((ctx, lc) =>
    lc.ReadFrom.Configuration(ctx.Configuration));

// 2. DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. AutoMapper
builder.Services.AddAutoMapper(Assembly.Load("HRLeaveSystem.Application"));

// 4. FluentValidation
builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssembly(Assembly.Load("HRLeaveSystem.Application"));
    });

// 5. Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Default
var app = builder.Build();

// Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

builder.Services.AddScoped<ILeaveRequestService, LeaveRequestService>();
builder.Services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
