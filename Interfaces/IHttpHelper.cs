namespace AV.ForeignExchangeRates.Front.Interfaces;

public interface IHttpHelper
{
    Task<string> GetAsync(string url);
}
