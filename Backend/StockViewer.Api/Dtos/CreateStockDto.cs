namespace StockViewer.Api;

/// <summary>
/// Represents the data transfer object (DTO) used for creating a new stock.
/// </summary>
public record class CreateStockDto
(
    /// <summary>
    /// Gets or sets the name of the stock.
    /// </summary>
    string StockName,

    /// <summary>
    /// Gets or sets the ID of the user associated with the stock.
    /// </summary>
    int UserId
);