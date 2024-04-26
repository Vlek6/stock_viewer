namespace StockViewer.Api.Entities;

/// <summary>
/// Represents a user entity in the StockViewer API.
/// </summary>
public class User
{
    public int Id { get; set; }

    public required string Login { get; set; }

    public string Password { get; set; } = string.Empty;

    public ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
