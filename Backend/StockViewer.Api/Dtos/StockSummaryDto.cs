namespace StockViewer.Api.Dtos;

/// <summary>
/// Represents the data transfer object (DTO) for summarizing stock information.
/// </summary>
public record class StockSummaryDto
(
    int Id,
    string StockName
);
