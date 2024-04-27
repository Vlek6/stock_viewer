using System.Reflection.Metadata.Ecma335;
using StockViewer.Api.Dtos;
using StockViewer.Api.Entities;

namespace StockViewer.Api;

/// <summary>
/// Provides mapping methods for converting between stock entities and DTOs.
/// </summary>
public static class StockMapping
{
    /// <summary>
    /// Converts a <see cref="CreateStockDto"/> to a <see cref="Stock"/>.
    /// </summary>
    /// <param name="stock">The <see cref="CreateStockDto"/> instance.</param>
    /// <returns>The corresponding <see cref="Stock"/> entity.</returns>
    public static Stock ToEntity(this CreateStockDto stock)
    {
        return new Stock()
        {
            StockSymbol = stock.StockSymbol,
            UserId = stock.UserId,
        };
    }

    /// <summary>
    /// Converts a <see cref="Stock"/> entity to a <see cref="StockSummaryDto"/>.
    /// </summary>
    /// <param name="stock">The <see cref="Stock"/> entity.</param>
    /// <returns>The corresponding <see cref="StockSummaryDto"/>.</returns>
    public static StockSummaryDto ToStockSummaryDto(this Stock stock)
    {
        return new(
            stock.Id,
            stock.StockSymbol
        );
    }

    /// <summary>
    /// Converts a <see cref="UpdateStockDto"/> to a <see cref="Stock"/> entity with the specified ID.
    /// </summary>
    /// <param name="stock">The <see cref="UpdateStockDto"/> instance.</param>
    /// <param name="id">The ID of the stock.</param>
    /// <returns>The corresponding <see cref="Stock"/> entity.</returns>
    public static Stock ToEntity(this UpdateStockDto stock, int id)
    {
        return new Stock()
        {
            Id = id,
            StockSymbol = stock.StockSymbol
        };
    }
}
