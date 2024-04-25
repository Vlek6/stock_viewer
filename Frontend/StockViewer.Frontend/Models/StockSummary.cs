namespace StockViewer.Frontend.Models;

public class StockSummary
{
    public int Id { get; set;}
    public required string Symbol { get; set; }
    public required string Name { get; set; }
}
