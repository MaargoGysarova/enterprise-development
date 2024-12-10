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


var builder = WebApplication.CreateBuilder(args);

// Изменение порта
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5001); // Задаем новый порт  5001
});


// Инициализация фиктивных данных или данных из внешнего источника
var pharmacyData = new PharmacyManagementData();

// Регистрация контроллеров
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(options =>
    {
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        options.IncludeXmlComments(xmlPath);
    });

// Регистрация репозиториев с использованием данных (или с пустыми списками для тестирования)
builder.Services.AddSingleton<IRepository<Pharmacy>>(new IPharmacyRepository(pharmacyData.Pharmacies));
builder.Services.AddSingleton<IRepository<Medicine>>(new IMedicineRepository(pharmacyData.Medicines));
builder.Services.AddSingleton<IRepository<PriceList>>(new IPriceListRepository(pharmacyData.PriceLists));

// Регистрация сервисов для работы с репозиториями
builder.Services.AddScoped<PharmacyService>();
builder.Services.AddScoped<MedicineService>();
builder.Services.AddScoped<PriceListService>();

// Регистрация AutoMapper для маппинга между сущностями и DTO
builder.Services.AddAutoMapper(typeof(Mapping));

// Создание и конфигурация приложения
var app = builder.Build();

// Включаем Swagger только в режиме разработки
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => Results.Redirect("/swagger")); // Перенаправление на Swagger
app.MapControllers();
app.Run();
