using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Тестовий endpoint
app.MapGet("/test", (HttpRequest request) =>
{
    // Отримуємо токен з заголовка
    var authHeader = request.Headers["Authorization"].ToString();
    var token = authHeader.Replace("Bearer ", "");

    if (string.IsNullOrEmpty(token))
        return Results.Unauthorized();

    return Results.Json(new
    {
        message = "ok",
        received_token = token
    });
});

app.Run("http://localhost:8000");