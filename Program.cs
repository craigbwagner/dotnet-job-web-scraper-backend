using dotnet_job_web_scraper_backend.Services;
using dotnet_job_web_scraper_backend.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "Job Web Scraper";
    config.Title = "Job Web Scraper v1";
    config.Version = "v1";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "TodoAPI";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}

app.MapGet("/get-elements", (string url, IParsingService parsingService) =>
{
    var result = parsingService.Fetch(url);
    return;
});

app.Run();
