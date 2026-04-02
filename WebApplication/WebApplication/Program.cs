using WebApplication.Endpoints;
using WebApplication.Models;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Minimal API endpoints
app.MapGet("/api/products/minimal", () => "Products from Minimal API");
app.MapGet("/api/products/minimal/{id}", (int id) => $"Product {id} from Minimal API");

var productsGroup = app.MapGroup("/api/products/group");
productsGroup.MapGet("/", () => "Products group");
productsGroup.MapGet("/{id}", (int id) => $"Product {id} from group");

// GET должны быть идемпотентными
app.MapGet("/api/customers", () => new[] { "Cutomer 1", "Customer 2" });
app.MapGet("/api/customers/{id}", (int id) => new { id, name = "Customer 1" });

// POST - не идемпотентны
app.MapPost("/app/customers", (Customer customer) =>
{
    // Логика создания пользователя

    // Возвращает HTTP-code 201, заголовок Location с Url на созданный ресурс и json в body
    return Results.Created($"/api/customers/{customer.Id}", customer);
});

// Группировка
var personsGroup = app.MapGroup("/api/persons");
personsGroup.MapGet("/", () => new[] { "Persona 1", "Persona 2" });

// Возвращаемое значение - используется класс Results
personsGroup.MapGet("/all", () => Results.Ok(new[] { "Persona 1", "Persona 2" }));

// Добавление эндпоинтов, вынесенных в методы расширения
app.MapGoods();

app.MapControllers();


app.Run();

// Не удалять! Без этого тесты не будут работать корректно
// Тесты используют WebApplicationFactory<Program> для создания тестового сервера
// и проверки работы маршрутов. Класс Program должен быть доступен для тестов.
public partial class Program { }
