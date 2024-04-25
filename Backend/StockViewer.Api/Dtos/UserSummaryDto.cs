namespace StockViewer.Api.Dtos;

public record class UserSummaryDto
(
    int Id,
    string Login,
    List<StockSummaryDto> Stocks
);
