namespace AV.ForeignExchangeRates.Front.Helpers;

public static class Constants
{
    public const string API_URL = "https://www.alphavantage.co/query?function=FX_DAILY";
    public const string API_KEY =   "M68D2QGRTGDVS1TR";

    public const string FX_DAILY_PROPERTY_NAME = "Time Series FX (Daily)";
    public const string METADATA_PROPERTY_NAME = "Meta Data";
    public const string LAST_REFRESH_PROPERTY_NAME = "5. Last Refreshed";

    public const string COOKIE_NAME = "AuthCookie";
}
