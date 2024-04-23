namespace StockViewer.Api.Entities;

public class Stock
{
    public int Id { get; set; }
    public required string StockName { get; set; }
    // public User? User { get; set; }
}
