namespace StockViewer.Api;

public record class CreateStockDto
(
    string StockName,
    int UserId
);