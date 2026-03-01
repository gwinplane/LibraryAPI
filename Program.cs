using Microsoft.EntityFrameworkCore;
using LibraryAPI.Data;

var builder = WebApplication.CreateBuilder(args); //→ наняли прораба

// Add services to the container
builder.Services.AddControllers(); //→ возьми инструмент контроллеров
builder.Services.AddOpenApi(); //→ возьми инструмент документации

// Подключаем MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build(); //→ прораб построил дом, дом готов к работе

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment()) //если мы в режиме разработки
{
    app.MapOpenApi(); //документация
}

app.UseHttpsRedirection(); //перенаправить на HTTPS если нужно
app.UseAuthorization(); //проверить есть ли доступ
app.MapControllers(); //подключить маршруты контроллеров

app.Run();
