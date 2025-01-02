using dotnet_job_web_scraper_backend.Services;
using dotnet_job_web_scraper_backend.Interfaces;

var builder = WebApplication.CreateBuilder(args);





builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IParsingService, ParsingService>();

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

app.MapGet("/get-elements", async (IParsingService parsingService) =>
{
    var result = await parsingService.Fetch();
    return Results.Ok(result.DocumentNode.InnerText); // Return raw HTML as a string or process it as needed
});

app.Run();
