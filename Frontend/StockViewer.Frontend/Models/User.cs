namespace StockViewer.Frontend.Models;

public class User
{
    public User(){
        Username = "";
        Password = "";
        FollowedStocks = new List<string>();
        PurchasedStocks = new List<PurchasedStock>();
        balance = 500;
    }
    public string? Username {get; set; }
    public string? Password {get; set;}
    private decimal balance {get; set;}
    private List<string> FollowedStocks {get; set;}
    private List<PurchasedStock> PurchasedStocks {get; set;}


    public void SetUsername(string? username){
        Username = username;
    }
    public void SetPassword(string? password){
        Password = password;
    }
    public void AddPurchasedStock(PurchasedStock Stock){
        PurchasedStocks.Add(Stock);
    }
    public void AddFollowedStock(string StockName){
        FollowedStocks.Add(StockName);
    }
    public List<PurchasedStock> GetPurchasedStocks(){
        return PurchasedStocks;
    }
    public string? GetUsername(){
        return Username;
    }

    public List<string> GetFollowedStocks(){
        return FollowedStocks;
    }
    public bool comparePassoword(string? passwrd){
        return Password == passwrd;
    }

}
