using StockViewer.Frontend.Models;

namespace StockViewer.Frontend.Clients;

public class StockClient(HttpClient httpClient)
{
    
    public string? symbol { get; set; }
    public async Task<StockData> GetStockDataAsync(){
        string ApiKey = httpClient.DefaultRequestHeaders.GetValues("api-key").First<String>();
        Console.WriteLine(ApiKey);
        string timeNow = DateTime.Now.Date.ToString("yyyy-MM-dd");
        string timeYrAgo = DateTime.Now.Date.AddYears(-1).ToString("yyyy-MM-dd");
        return await httpClient.GetFromJsonAsync<StockData>($"historical-price-full/{symbol}?/&from={timeYrAgo}&to={timeNow}&{ApiKey}") ?? new StockData();
    }
}
