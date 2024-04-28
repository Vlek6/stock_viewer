using System.ComponentModel.DataAnnotations;

namespace StockViewer.Frontend.Models;

public class User
{
    public int UserId { get; set; }

    [Required(ErrorMessage = "This field is required.")]
    [StringLength(20)]
    public string? Username {get; set; }
    
    [Required(ErrorMessage = "This field is required.")]
    [StringLength(20)]
    public string? Password {get; set;}
    // private decimal balance {get; set;}
    public List<StockSummary>? FollowedStocks {get; set;}
    // private List<PurchasedStock> PurchasedStocks {get; set;}


    public void SetUsername(string? username){
        Username = username;
    }
    public void SetPassword(string? password){
        Password = password;
    }
    // public void AddPurchasedStock(PurchasedStock Stock){
    //     PurchasedStocks.Add(Stock);
    // }

    // public List<PurchasedStock> GetPurchasedStocks(){
    //     return PurchasedStocks;
    // }
    public string? GetUsername(){
        return Username;
    }

    public List<StockSummary> GetFollowedStocks(){
        return FollowedStocks;
    }
    public bool comparePassoword(string? passwrd){
        return Password == passwrd;
    }

}
