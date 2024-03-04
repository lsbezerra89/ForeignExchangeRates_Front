using AV.ForeignExchangeRates.Front.Helpers;
using AV.ForeignExchangeRates.Front.Interfaces;
using AV.ForeignExchangeRates.Front.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AV.ForeignExchangeRates.Front.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly IHttpHelper _httpHelper;

    public HomeController(IHttpHelper httpHelper)
    {
        _httpHelper = httpHelper;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("fx-daily")]
    public async Task<IActionResult> OnGet([FromQuery] string fromCurrency, [FromQuery] string toCurrency)
    {
        var url = $"{Constants.API_URL}&from_symbol={fromCurrency}&to_symbol={toCurrency}&apikey={Constants.API_KEY}";

        var responseString = await _httpHelper.GetAsync(url);

        var jsonObject = JsonConvert.DeserializeObject<JObject>(responseString);

        var lastRefreshedProperty = ((JObject)jsonObject.GetValue(Constants.METADATA_PROPERTY_NAME)).GetValue(Constants.LAST_REFRESH_PROPERTY_NAME);
        var lastRefreshedDateTime = DateTime.Parse(lastRefreshedProperty.ToString());

        var forexDailyList = (JObject)jsonObject.GetValue(Constants.FX_DAILY_PROPERTY_NAME);
        var forexDailyLastRefreshed = forexDailyList[lastRefreshedDateTime.ToString("yyyy-MM-dd")];

        var forexDaily = forexDailyLastRefreshed.ToObject<ForexDailyPrice>();
        forexDaily.LastRefresh = lastRefreshedDateTime.ToString("yyyy-MM-dd HH:mm");

        return Json(forexDaily);
    }
}