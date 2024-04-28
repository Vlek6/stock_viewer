using Newtonsoft.Json;
using StockViewer.Frontend.Models;
namespace StockViewer.Frontend.Clients;

public class UsersClient(HttpClient httpClient)
{
    public User? currentUser { get; set; }
    private List<StockSummary>? stocks { get; set; }
    public async Task<User?> GetUser(string username) 
        => await httpClient.GetFromJsonAsync<User>($"users/{username}");
    public async Task AddUserAsync(string username, string password)
    {
        NewUser newUser = new NewUser()
        {
            Login = username,
            Password = password
        };
        await httpClient.PostAsJsonAsync<NewUser>("users/", newUser);
        // User? user = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());
        // if (user is not null)
        //     users.Add(user);
    }
    public async Task<List<StockSummary>> GetFollowedStocksAsync(string user){
        User? tmpUser =  await httpClient.GetFromJsonAsync<User>($"users/{user}");
        if(tmpUser is not null) return tmpUser.FollowedStocks!;
        else return new List<StockSummary>();

    }

    private StockSummary? GetStockSummaryById(int id)
    {
        if (currentUser is not null)
        {
            StockSummary? stock = currentUser.GetFollowedStocks().Find(stock => stock.Id == id);
            ArgumentNullException.ThrowIfNull(stock);
            return stock;
        }
        return null;
    }

    public void DeleteStockById(int id)
    {
        // var stock = GetStockSummaryById(id);
        // if (stock != null && currentUser is not null)
        // {
        //     currentUser.RemoveFollowedStock(stock);

        // }
    }

    public async void AddStockAsync(User user, StockSummary stock)
    {
        UserStock userstock = new UserStock(){
            userid = user.UserId,
            stockName = stock.Symbol
        };
        await httpClient.PostAsJsonAsync<UserStock>("stocks", userstock);
    }
    private async Task<User?> GetUserAsync(string username)
        => await httpClient.GetFromJsonAsync<User>($"users/{username}");

    public async Task<bool> CheckUserAsync(User user)
    {
        User? DBuser = await GetUserAsync(user.Username!);
        if (DBuser is not null)
        {
            if (user.Password == DBuser.Password) return true;
            else return false;
        }
        return false;
    }
}


