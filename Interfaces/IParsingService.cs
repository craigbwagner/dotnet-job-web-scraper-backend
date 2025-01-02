namespace dotnet_job_web_scraper_backend.Interfaces;
using HtmlAgilityPack;


public interface IParsingService
{
    Task<HtmlDocument> Fetch();
}
