using dotnet_job_web_scraper_backend.Interfaces;
using PuppeteerSharp;

namespace dotnet_job_web_scraper_backend.Services
{
    public class ParsingService : IParsingService
    {
        public async Task<string> Fetch()
        {
            // Ensure Chromium is downloaded
            await new BrowserFetcher().DownloadAsync();

            // Launch a headless browser
            using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true // Set to false if you want to see the browser UI
            });

            // Open a new page
            using var page = await browser.NewPageAsync();

            // Navigate to the URL
            var url = "https://www.hardkoded.com/blog/ui-testing-with-puppeteer-released";
            await page.GoToAsync(url);

            // Select all <p> elements using QuerySelectorAllAsync
            var paragraphHandles = await page.QuerySelectorAllAsync("div");

            // Check if any <p> elements were found
            if (paragraphHandles.Length == 0)
            {
                throw new Exception("No <p> elements found on the page.");
            }

            // Extract innerText for each <p> element
            var paragraphs = new List<string>();
            foreach (var handle in paragraphHandles)
            {
                var innerText = await handle.EvaluateFunctionAsync<string>("el => el.innerText");
                paragraphs.Add(innerText);
            }

            // Join the extracted texts into a single string, separated by newlines
            var result = string.Join("\n", paragraphs);

            // Return the concatenated result
            return result;
        }
    }
}
