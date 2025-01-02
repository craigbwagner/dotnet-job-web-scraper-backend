var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "Job Web Scraper";
    config.Title = "Job Web Scraper v1";
    config.Version = "v1";
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
