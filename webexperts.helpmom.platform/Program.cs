using Microsoft.EntityFrameworkCore;
using webexperts.helpmom.platform.Chat.Application.Internal.CommandServices;
using webexperts.helpmom.platform.Chat.Application.Internal.QueryServices;
using webexperts.helpmom.platform.Chat.Domain.Repositories;
using webexperts.helpmom.platform.Chat.Domain.Services;
using webexperts.helpmom.platform.Chat.Infraestructure.Persistence;
using webexperts.helpmom.platform.Chat.Infraestructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 👇 REGISTRA LOS SERVICIOS DEL CHAT
builder.Services.AddScoped<CreateMessageCommandService>();
builder.Services.AddScoped<GetMessagesByPatientIdQueryService>();

builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<MessageDomainService>();

builder.Services.AddDbContext<ChatDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// 👇 CORS CONFIGURACIÓN
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowViteFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // 👈 tu frontend Vite
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting(); // 👈 NECESARIO antes de usar CORS
app.UseCors("AllowViteFrontend"); // 👈 Aquí se aplica CORS

app.UseAuthorization();

app.MapControllers();

app.Run();
