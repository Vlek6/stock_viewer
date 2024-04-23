namespace StockViewer.Frontend.Models;

public class PurchasedStock
{
    public PurchasedStock(string Symbol, decimal amount){
        StockSymbol = Symbol;
        Amount = amount;
    }
    public PurchasedStock(){
        StockSymbol = string.Empty;
        Amount = 0;
    }
    private string? StockSymbol { get; set; }
    private decimal Amount { get; set; }
}
