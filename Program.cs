var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var scores = new List<int>();

app.MapGet("/", () => "API do jogo rodando 🚀");

app.MapPost("/score", (int score) =>
{
    scores.Add(score);
    return Results.Ok(new { message = "Score salvo!" });
});

app.MapGet("/ranking", () =>
{
    return scores.OrderByDescending(s => s).Take(10);
});

// PORTA DO RENDER
var port = Environment.GetEnvironmentVariable("PORT") ?? "3000";
app.Urls.Add($"http://*:{port}");

app.Run();
