using Newtonsoft.Json.Linq;
using System.Text.Json;
using PersonalBusinessManagement.Models;

namespace PersonalBusinessManagement.Data.ExchangeRates;

public static class CurrencyFileHandler
{
    private const string ExchangeRatesPath = "Data\\ExchangeRates\\ExchangeRates.json";
    private const string apiKeyPath = "Data\\ExchangeRates\\free - Copy.currconv.txt";
    private const string errorReportPath = "Data\\ExchangeRates\\ErrorReport.txt";
    public static async Task<Currency?> GetExchangeRates()
    {
        var fileContent = await File.ReadAllTextAsync(ExchangeRatesPath);
        var exchangeRate = JsonSerializer.Deserialize<IEnumerable<Currency>>(fileContent);
        return exchangeRate?.FirstOrDefault();
    }

    public static async Task<string[]> GenerateLinks()
    {
        var apiKey = await File.ReadAllTextAsync(apiKeyPath);
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
            using var client = new HttpClient();
            var getRequests = await GenerateLinks();
            JObject json = JObject.Parse($"{{ \"updated\": \"{DateTime.Now}\"}}");
            for (int i = 0; i < getRequests.Length; i++)
            {
                var response = JObject.Parse(await client.GetStringAsync(getRequests[i]));
                json.Merge(response);
            }
            await File.WriteAllTextAsync(ExchangeRatesPath, $"[\n{json}\n]");
        }
        catch (Exception e)
        {
            await File.AppendAllTextAsync($"\n\n{errorReportPath}", "Error!  Couldn't update or write" +
                 $" successfully {DateTime.Now}\n{e.Message}");
        }
    }



}

