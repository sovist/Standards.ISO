using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Standards.ISO3166.CountryCodes.Providers
{
    public class WikipediaIso3166Provider
    {
        public async Task<List<CountryCode>> Load()
        {
            var page = await LoadHtmlPage();

            var tableRows = LoadTableRows();

            var countryCodes = new List<CountryCode>();

            foreach (var tableRow in tableRows)
            {
                var columns = tableRow.SelectNodes(".//td");

                var name = columns[0].SelectSingleNode(".//a").InnerText;

                var alpha2 = columns[1].InnerText;

                var alpha3 = columns[2].InnerText;

                var numeric = columns[3].InnerText;

                int.TryParse(numeric, out var numericNumber);

                countryCodes.Add(new CountryCode(alpha2, alpha3, numericNumber, name));
            }

            return countryCodes;

            async Task<string> LoadHtmlPage()
            {
                var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Standards.ISO3166.CountryCodes.Providers", "1.0.0"));

                return await httpClient.GetStringAsync("https://en.wikipedia.org/wiki/ISO_3166-1");
            }

            List<HtmlNode> LoadTableRows()
            {
                var htmlDocument = new HtmlDocument();

                htmlDocument.LoadHtml(page);

                var table = htmlDocument.DocumentNode
                    .SelectNodes(".//table[@class='wikitable sortable sticky-header'] //tbody")
                    .Single();

                return table
                    .SelectNodes(".//tr")
                    //Skip the header row
                    .Skip(1)
                    .ToList();
            }
        }
    }
}