using StockViewer.Frontend.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace StockViewer.Frontend.Clients
{
    /// <summary>
    /// Provides methods for interacting with user data and stock data via HTTP requests.
    /// </summary>
    public class UsersClient
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersClient"/> class with the specified HTTP client.
        /// </summary>
        /// <param name="httpClient">The HTTP client used to make requests.</param>
        public UsersClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Gets or sets the current user.
        /// </summary>
        public User? CurrentUser { get; set; }

        /// <summary>
        /// Gets or sets the list of followed stocks.
        /// </summary>
        private List<StockSummary>? Stocks { get; set; }

        /// <summary>
        /// Retrieves user data asynchronously.
        /// </summary>
        /// <param name="Login">The Login of the user to retrieve.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The task result contains the retrieved user data.</returns>
        public async Task<User?> GetUserAsync(string Login){
            User? user = await _httpClient.GetFromJsonAsync<User>($"users/{Login}");  
            return user;
        }

        public async Task<User?> GetUserAsync2(string user){
            User? dbUser = await GetUserAsync(user);
            return dbUser;
        }
        // {
        //     User? response 
        //     // Console.WriteLine("GetUserAsync()");
        //     // Console.WriteLine(response.Login);
        //     // if(response == null) return null;
        //     // else return response;
        // }     

        /// <summary>
        /// Adds a new user asynchronously.
        /// </summary>
        /// <param name="Login">The Login of the new user.</param>
        /// <param name="password">The password of the new user.</param>
        public async Task AddUserAsync(string Login, string password)
        {
            NewUser newUser = new NewUser()
            {
                Login = Login,
                Password = password
            };
            await _httpClient.PostAsJsonAsync<NewUser>("users/", newUser);
        }

        /// <summary>
        /// Retrieves the list of followed stocks for a user asynchronously.
        /// </summary>
        /// <param name="user">The Login of the user.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The task result contains the list of followed stocks.</returns>
        public async Task<List<StockSummary>?> GetFollowedStocksAsync(string user)
        {
            User? tmpUser = await GetUserAsync(user);
            if(tmpUser is not null){
                return tmpUser.Stocks;
            }
            else return null;
        }

        /// <summary>
        /// Deletes a stock by its ID.
        /// </summary>
        /// <param name="id">The ID of the stock to delete.</param>
        public async Task DeleteStockByIdAsync(int id)
        {
            await _httpClient.DeleteAsync($"stocks/{id}");
        }

        /// <summary>
        /// Adds a stock asynchronously for a user.
        /// </summary>
        /// <param name="user">The user for whom to add the stock.</param>
        /// <param name="stock">The stock to add.</param>
        public async Task AddStockAsync(User user, StockSummary stock)
        {
            UserStock userstock = new UserStock()
            {
                userid = user.Id,
                stockSymbol = stock.StockSymbol
            };
            await _httpClient.PostAsJsonAsync<UserStock>("stocks", userstock);
        }

        /// <summary>
        /// Retrieves a user asynchronously.
        /// </summary>
        /// <param name="Login">The Login of the user to retrieve.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The task result contains the retrieved user.</returns>
        // private async Task<User?> GetUserAsync(string Login)
        // {
        //     return await _httpClient.GetFromJsonAsync<User>($"users/{Login}");
        // }

        /// <summary>
        /// Checks if the provided user exists and if the password matches.
        /// </summary>
        /// <param name="user">The user to check.</param>
        /// <returns><c>true</c> if the user exists and the password matches; otherwise, <c>false</c>.</returns>
        public async Task<bool> CheckUserAsync(User user)
        {
            User? dbUser = await GetUserAsync(user.Login!);
            return dbUser != null && user.Password == dbUser.Password;
        }

        // You can continue documenting the other methods similarly.
    }
}
