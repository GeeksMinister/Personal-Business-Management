using System.Text.Json.Serialization;

namespace PersonalBusinessManagement.Models;

public sealed class Currency
{
#pragma warning disable CS8618
    [JsonPropertyName("updated")]
    public string UpdateDate { get; set; }
    [JsonPropertyName("USD_SEK")]
    public double USD_SEK { get; set; }
    [JsonPropertyName("EUR_SEK")]
    public double EUR_SEK { get; set; }
    [JsonPropertyName("GBP_SEK")]
    public double GBP_SEK { get; set; }
    [JsonPropertyName("CAD_SEK")]
    public double CAD_SEK { get; set; }
    [JsonPropertyName("CHF_SEK")]
    public double CHF_SEK { get; set; }
    [JsonPropertyName("JPY_SEK")]
    public double JPY_SEK { get; set; }

    public override string ToString()
    {
        return $"Updated:  {UpdateDate}\n" +
            $"USD: {USD_SEK}\n" +
            $"EUR: {EUR_SEK}\n" +
            $"GBP: {GBP_SEK}\n" +
            $"CAD: {CAD_SEK}\n" +
            $"CHF: {CHF_SEK}\n" +
            $"JPY: {JPY_SEK}\n";
    }
}


