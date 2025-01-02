using dotnet_job_web_scraper_backend.Interfaces;
using HtmlAgilityPack;

namespace dotnet_job_web_scraper_backend.Services;

public class ParsingService : IParsingService
{
   public async Task<HtmlDocument> Fetch()
{
    var url = "https://www.linkedin.com/jobs/";
    HtmlWeb web = new HtmlWeb();
    var htmlDoc = await web.LoadFromWebAsync(url);
    return htmlDoc;
}
}
