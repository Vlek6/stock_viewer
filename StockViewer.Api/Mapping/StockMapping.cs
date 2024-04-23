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
            StockName = stock.StockName
        };
    }

    public static StockSummaryDto ToStockSummaryDto(this Stock stock)
    {
        return new(
            stock.StockName
        );
    }

    // public static 
}
