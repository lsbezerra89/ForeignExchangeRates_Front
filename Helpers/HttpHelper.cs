using AV.ForeignExchangeRates.Front.Interfaces;
using Newtonsoft.Json;

namespace AV.ForeignExchangeRates.Front.Helpers;

public class HttpHelper : IHttpHelper, IDisposable
{
    private readonly HttpClient httpClient;

    public HttpHelper()
    {
        httpClient = new HttpClient();
    }

    public async Task<string> GetAsync(string url)
    {
        HttpResponseMessage response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        else
        {
            throw new HttpRequestException($"Error: {response.StatusCode} - {response.ReasonPhrase}");
        }
    }

    public void Dispose()
    {
        httpClient.Dispose();
    }
}