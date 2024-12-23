using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using PharmacyManagementSystem.Api.Dto;
using PharmacyManagementSystem.Api.Service;
using PharmacyManagementSystem.Domain;
using PharmacyManagementSystem.Domain.Repositories;
using System.IO;
using System;
using PharmacyManagementSystem.Api;
using PharmacyManagementSystem.Domain.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Настройка подключения к базе данных
var connectionString = builder.Configuration.GetConnectionString("MySQL");
builder.Services.AddDbContext<PharmacyDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 39)),
    b => b.MigrationsAssembly("PharmacyManagementSystem.Domain")));

// Добавляем CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor", policy =>
    {
        policy.WithOrigins("http://localhost:5295")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Изменение порта
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5001); // Задаем порт 5001
});

// Регистрация контроллеров и Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

// Регистрация репозиториев
builder.Services.AddScoped<IRepository<Pharmacy>, IPharmacyRepository>();
builder.Services.AddScoped<IRepository<Medicine>, IMedicineRepository>();
builder.Services.AddScoped<IRepository<PriceList>, IPriceListRepository>();

// Регистрация сервисов
builder.Services.AddScoped<IService<PharmacyGetDto, PharmacyPostDto>, PharmacyService>();
builder.Services.AddScoped<IService<MedicineGetDto, MedicinePostDto>, MedicineService>();
builder.Services.AddScoped<IService<PriceListGetDto, PriceListPostDto>, PriceListService>();

// Настройка AutoMapper
builder.Services.AddAutoMapper(typeof(Mapping));

// Создание и конфигурация приложения
var app = builder.Build();

// Подключение CORS
app.UseCors("AllowBlazor");

// Включение Swagger только в режиме разработки
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapGet("/", () => Results.Redirect("/swagger")); // Перенаправление на Swagger
}

// Включение маршрутизации контроллеров
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
