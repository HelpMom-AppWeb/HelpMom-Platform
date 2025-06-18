using Microsoft.EntityFrameworkCore;
using webexperts.helpmom.platform.API.Application.Internal.CommandServices;
using webexperts.helpmom.platform.API.Application.Internal.QueryServices;
using webexperts.helpmom.platform.API.Domain.Repositories;
using webexperts.helpmom.platform.API.Domain.Services;
using webexperts.helpmom.platform.API.Infraestructure.Persistence.EFC.repositories;
using webexperts.helpmom.platform.API.Shared.Domain.Repositories;
using webexperts.helpmom.platform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using webexperts.helpmom.platform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using webexperts.helpmom.platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using webexperts.helpmom.platform.API.Application.Internal.QueryServices;

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

// Shared Bounded Context
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Medication 
builder.Services.AddScoped<IMedicationQueryService, MedicationQueryServices>();
builder.Services.AddScoped<IMedicationCommandService, MedicationCommandServices>();
builder.Services.AddScoped<IMedicationRepository, MedicationRepository>();

// Prescription
builder.Services.AddScoped<IPrescriptionQueryService, PrescriptionQueryService>();

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