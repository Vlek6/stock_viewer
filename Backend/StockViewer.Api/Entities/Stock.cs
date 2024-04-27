namespace StockViewer.Api.Entities;

/// <summary>
/// Represents a stock entity in the StockViewer API.
/// </summary>
public class Stock
{
    public int Id { get; set; }
    public required string StockSymbol { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }
}
