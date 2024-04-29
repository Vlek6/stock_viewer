using StockViewer.Frontend.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockViewer.Frontend.Clients
{
    /// <summary>
    /// Provides methods for interacting with stock data via HTTP requests.
    /// </summary>
    public class StockClient
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="StockClient"/> class with the specified HTTP client.
        /// </summary>
        /// <param name="httpClient">The HTTP client used to make requests.</param>
        public StockClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Gets or sets the symbol of the stock.
        /// </summary>
        public string? Symbol { get; set; }

        /// <summary>
        /// Retrieves historical stock data asynchronously.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The task result contains the retrieved stock data.</returns>
        public async Task<StockData> GetStockDataAsync()
        {
            // Retrieve API key from request headers
            string apiKey = _httpClient.DefaultRequestHeaders.GetValues("api-key").First();

            // Get current date and date one year ago
            string timeNow = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string timeYrAgo = DateTime.Now.Date.AddYears(-1).ToString("yyyy-MM-dd");

            // Construct URL for historical data request
            string requestUrl = $"historical-price-full/{Symbol}?/&from={timeYrAgo}&to={timeNow}&{apiKey}";

            // Make HTTP GET request and deserialize response
            return await _httpClient.GetFromJsonAsync<StockData>(requestUrl) ?? new StockData();
        }
    }
}
