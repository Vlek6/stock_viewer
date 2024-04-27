namespace StockViewer.Api.Dtos;

/// <summary>
/// Represents the data transfer object (DTO) used for updating stock information.
/// </summary>
public record class UpdateStockDto
(
    string StockSymbol
);
