namespace StockViewer.Api;

/// <summary>
/// Represents the data transfer object (DTO) used for creating a new stock.
/// </summary>
public record class CreateStockDto
(
    string StockName,
    int UserId
);