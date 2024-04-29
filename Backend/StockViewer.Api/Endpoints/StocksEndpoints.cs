using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using StockViewer.Api.Data;
using StockViewer.Api.Dtos;
using StockViewer.Api.Entities;

namespace StockViewer.Api.Endpoints;

/// <summary>
/// Provides endpoints for managing stocks.
/// </summary>
public static class StocksEndpoints
{
    const string GetStockEndpointName = "GetStock";
    /// <summary>
    /// Maps endpoints related to stocks.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <returns>A route group builder for stocks endpoints.</returns>
    public static RouteGroupBuilder MapStocksEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("stocks").WithParameterValidation();

        // GET stocks/
        group.MapGet("/", async (StockViewerContext dbContext) =>
            await dbContext.Stocks.Select(stock => stock.ToStockSummaryDto()).AsNoTracking().ToListAsync()
        );


        // GET stocks/{id}
        group.MapGet("/{id}", async (int id, StockViewerContext dbContext) =>
            {
                Stock? stock = await dbContext.Stocks.FindAsync(id);

                return stock is null ? Results.NotFound() : Results.Ok(stock.ToStockSummaryDto());
            })
            .WithName(GetStockEndpointName);

        // POST stocks/
        group.MapPost("/", async (CreateStockDto newStock, StockViewerContext dbContext) =>
        {
            Stock stock = newStock.ToEntity();

            dbContext.Add(stock);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetStockEndpointName, new { id = stock.Id }, stock.ToStockSummaryDto());
        }
        );

        // PUT stocks/{id}
        group.MapPut("/{id}", async (int id, UpdateStockDto updatedStock, StockViewerContext dbContext) =>
        {
            var existingStock = await dbContext.Stocks.FindAsync(id);

            if (existingStock is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingStock)
                                    .CurrentValues
                                    .SetValues(updatedStock.ToEntity(id));
            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        }
        );

        // DELETE stocks/{id}
        group.MapDelete("/{id}", async (int id, StockViewerContext dbContext) =>
            {
                await dbContext.Stocks
                                .Where(stock => stock.Id == id)
                                .ExecuteDeleteAsync();
                return Results.NoContent();
            }
        );
        return group;
    }
}
