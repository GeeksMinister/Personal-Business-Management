using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace PersonalBusinessManagement.Data.ExchangeRates;

public static class CurrencyFileHandler
{
    private const string currencyFile = "Data\\ExchangeRates\\ExchangeRates.json";
    public static Currency? GetExchangeRates()
    {
        var fileContent = File.ReadAllText(currencyFile);
        var jsonObj = JsonSerializer.Deserialize<IEnumerable<Currency>>(fileContent);
        return jsonObj?.FirstOrDefault();
    }

    public static async Task<string[]> GenerateLinks()
    {
        var apiKey = await File.ReadAllTextAsync("free - Copy.currconv.txt");
        return new[]
        {
            "https://free.currconv.com/api/v7/convert?q=USD_SEK,EUR_SEK&compact=ultra&apiKey=" + apiKey,
            "https://free.currconv.com/api/v7/convert?q=GBP_SEK,CAD_SEK&compact=ultra&apiKey=" + apiKey,
            "https://free.currconv.com/api/v7/convert?q=CHF_SEK,JPY_SEK&compact=ultra&apiKey=" + apiKey,
        };
    }

    public static async Task UpdateExchangeRates()
    {
        try
        {
            var client = new HttpClient();
            var getRequests = await GenerateLinks();
            JObject json = JObject.Parse($"{{ \"updated\": \"{DateTime.Now}\"}}");
            for (int i = 0; i < getRequests.Length; i++)
            {
                var response = JObject.Parse(await client.GetStringAsync(getRequests[i]));
                json.Merge(response);
            }
            await File.WriteAllTextAsync("ExchangeRates.json", $"[\n{json}\n]");
        }
        catch (Exception e)
        {
            File.WriteAllText($"ErrorReport.txt", "Error!  Couldn't update or write" +
                 $" successfully {DateTime.Now}\n{e.Message}\n\n");
        }
    }



}

