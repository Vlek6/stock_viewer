﻿using Microsoft.EntityFrameworkCore;
using StockViewer.Api.Data;
using StockViewer.Api.Dtos;
using StockViewer.Api.Entities;

namespace StockViewer.Api.Endpoints;

/// <summary>
/// Provides endpoints for managing users.
/// </summary>
public static class UsersEndpoints
{

    const string GetUserEndpointName = "GetUser";
    /// <summary>
    /// Maps endpoints related to users.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <returns>A route group builder for users endpoints.</returns>
    public static RouteGroupBuilder MapUsersEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("users").WithParameterValidation();

        //GET /users
        group.MapGet("/", async (StockViewerContext dbContext) =>
            await dbContext.Users
                                .Include(user => user.Stocks)
                                .Select(user => user.ToUserSummaryDto())
                                .AsNoTracking()
                                .ToListAsync()
        );

        //GET /users/{id}
        group.MapGet("/{UserLogin}", async (string UserLogin, StockViewerContext dbContext) =>
        {
            User? user = await dbContext.Users
                                            .Include(user => user.Stocks)
                                            .Where(user => user.Login == UserLogin)
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync();

            return user is null ? Results.NotFound() : Results.Ok(user.ToUserSummaryDto());
        })
        .WithName(GetUserEndpointName);

        // POST /users
        group.MapPost("/", async (CreateUserDto newUser, StockViewerContext dbContext) =>
        {
            User user = newUser.ToEntity();

            dbContext.Add(user);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetUserEndpointName, new { id = user.Id }, user.ToUserSummaryDto());
        });

        // PUT /users/{id}
        group.MapPut("/{id}", async (int id, UpdateUserDto updatedUser, StockViewerContext dbContext) =>
        {
            var existingUser = await dbContext.Users.FindAsync(id);

            if (existingUser is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingUser)
                                .CurrentValues
                                .SetValues(updatedUser.ToEntity(id));
            await dbContext.SaveChangesAsync();
            return Results.NoContent();
        });

        // DELETE /users/{id}
        group.MapDelete("/{id}", async (int id, StockViewerContext dbContext) =>
        {
            await dbContext.Users
                            .Where(user => user.Id == id)
                            .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;


    }


}
