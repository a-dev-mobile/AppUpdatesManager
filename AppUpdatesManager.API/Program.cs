using System.Reflection;
using AppUpdatesManager.Application.Services.Contracts;
using AppUpdatesManager.Application.Services.Implementations;
using AppUpdatesManager.Domain.Interfaces;
using AppUpdatesManager.Infrastructure.Data;
using AppUpdatesManager.Infrastructure.Repositories;
using LinkShortener.API.SwaggerExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Настройка логирования
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Logging.SetMinimumLevel(LogLevel.Debug);

// Добавление и настройка контекста базы данных
builder.Services.AddDbContext<AppUpdatesManagerDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


// Регистрация  в DI контейнере
// builder.Services.AddScoped<IAppUpdateRepository, AppUpdateRepository>();
// builder.Services.AddScoped<IAppUpdateService, AppUpdateService>();

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
    options.SchemaFilter<CustomSchemaFilter>();
    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
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
app.MapControllers();
app.Run();
