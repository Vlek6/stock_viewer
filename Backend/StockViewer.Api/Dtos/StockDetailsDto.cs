namespace StockViewer.Api.Dtos;

/// <summary>
/// Represents the data transfer object (DTO) for displaying stock details.
/// </summary>public record class StockDetailsDto
public record class StockDetailsDto
(
int Id,
string StockName,
int UserId
);
