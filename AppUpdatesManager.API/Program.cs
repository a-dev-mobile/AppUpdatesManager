using AppUpdatesManager.Application.Services.Contracts;
using AppUpdatesManager.Application.Services.Implementations;
using AppUpdatesManager.Domain.Interfaces;
using AppUpdatesManager.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Настройка логирования
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Logging.SetMinimumLevel(LogLevel.Debug);


// Регистрация  в DI контейнере
builder.Services.AddScoped<IAppUpdateRepository, AppUpdateRepository>();
builder.Services.AddScoped<IAppUpdateService, AppUpdateService>();

// Добавление сервисов для контроллеров
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{

    options.SwaggerDoc("v1", new OpenApiInfo
    {

        Version = "v1",
        Title = "App Updates Manager",
        Description = "Application update control",
        Contact = new OpenApiContact
        {
            Name = "Dmitriy Trofimov",
            Email = "wayofdt@gmail.com",

        },

    });

});
// Add CORS services and define the "AllowAll" policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
var app = builder.Build();


app.UseCors("AllowAll");
app.UsePathBase("/app-update-api");
app.UseForwardedHeaders();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/app-update-api/swagger/v1/swagger.json", "My API V1");
});

app.Run();
