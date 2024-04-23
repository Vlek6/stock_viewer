namespace StockViewer.Api.Entities;

public class User
{
    public int Id { get; set; }

    public required string Login { get; set; }

    public string Password { get; set; } = string.Empty;

    // public Stock? Stock { get; set; }
}
