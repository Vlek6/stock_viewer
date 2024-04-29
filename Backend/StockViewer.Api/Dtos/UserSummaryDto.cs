namespace StockViewer.Api.Dtos;

/// <summary>
/// Represents the data transfer object (DTO) for summarizing user information.
/// </summary>
public record class UserSummaryDto
(
    int Id,
    string Login,
    string Password,
    List<StockSummaryDto> Stocks
);
