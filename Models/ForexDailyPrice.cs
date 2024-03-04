using Newtonsoft.Json;

namespace AV.ForeignExchangeRates.Front.Models;

public class ForexDailyPrice
{
    [JsonProperty("1. open")]
    public string Open { get; set; } = string.Empty;
    [JsonProperty("2. high")]
    public string High { get; set; } = string.Empty;
    [JsonProperty("3. low")]
    public string Low { get; set; } = string.Empty;
    [JsonProperty("4. close")]
    public string Close { get; set; } = string.Empty;
    public string LastRefresh { get; set; } = string.Empty;
}
