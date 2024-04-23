﻿using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using StockViewer.Api.Data;
using StockViewer.Api.Dtos;
using StockViewer.Api.Entities;

namespace StockViewer.Api.Endpoints;

public static class StocksEndpoints
{
    const string GetStockEndpointName = "GetStock";
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

                return stock is null ? Results.NotFound() : Results.Ok(stock);
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

            if(existingStock is null)
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

        return group;
    }
}
