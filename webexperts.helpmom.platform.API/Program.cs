using Microsoft.EntityFrameworkCore;
using webexperts.helpmom.platform.API.Appointments.Application.Internal.CommandServices;
using webexperts.helpmom.platform.API.Appointments.Application.Internal.QueryServices;
using webexperts.helpmom.platform.API.Appointments.Domain.Repositories;
using webexperts.helpmom.platform.API.Appointments.Domain.Services;
using webexperts.helpmom.platform.API.HealthMonitoring.Application.Internal.CommandServices;
using webexperts.helpmom.platform.API.HealthMonitoring.Application.Internal.QueryServices;
using webexperts.helpmom.platform.API.HealthMonitoring.Domain.Repositories;
using webexperts.helpmom.platform.API.HealthMonitoring.Domain.Services;
using webexperts.helpmom.platform.API.HealthMonitoring.Infrastructure.Persistence.EFC.Repositories;
using webexperts.helpmom.platform.API.Shared.Domain.Repositories;
using webexperts.helpmom.platform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using webexperts.helpmom.platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using webexperts.helpmom.platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

if (connectionString == null) throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    else if (builder.Environment.IsProduction())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error);
});

builder.Services.AddSwaggerGen(options => { options.EnableAnnotations(); });

// Dependency Injection
builder.Services.AddScoped<IAppointmentCommandService, AppointmentCommandService>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentQueryService, AppointmentQueryService>();

// Shared Bounded Context
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Health Monitoring Bounded Context
builder.Services.AddScoped<IHealthDataCommandService, HealthDataCommandService>();
builder.Services.AddScoped<IHealthDataQueryService, HealthDataQueryService>();
builder.Services.AddScoped<IHealthMonitoringRepository, HealthDataRepository>();


var app = builder.Build();

// Verify if the database exists and create it if it doesn't
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply CORS Policy
app.UseCors("AllowAllPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();