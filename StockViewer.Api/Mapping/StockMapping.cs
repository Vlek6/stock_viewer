using System.Reflection.Metadata.Ecma335;
using StockViewer.Api.Dtos;
using StockViewer.Api.Entities;

namespace StockViewer.Api;

public static class StockMapping
{
    public static Stock ToEntity(this CreateStockDto stock)
    {
        return new Stock()
        {
            StockName = stock.StockName,
            UserId = stock.UserId,
        };
    }

    public static StockSummaryDto ToStockSummaryDto(this Stock stock)
    {
        return new(
            stock.StockName,
            stock.UserId
        );
    }

    public static Stock ToEntity(this UpdateStockDto stock, int id)
    {
        return new Stock()
        {
            Id = id,
            StockName = stock.StockName
        };
    }
}
