using Microsoft.EntityFrameworkCore;
using StockViewer.Api.Data;
using StockViewer.Api.Dtos;
using StockViewer.Api.Entities;

namespace StockViewer.Api.Endpoints;

public static class UsersEndpoints
{

    const string GetUserEndpointName = "GetUser";
    public static RouteGroupBuilder MapUsersEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("users").WithParameterValidation();

        //GET /users
        group.MapGet("/", async (StockViewerContext dbContext) =>
            await dbContext.Users.Select(user => user.ToUserSummaryDto()).AsNoTracking().ToListAsync()
        );

        //GET /users/{id}
        group.MapGet("/{id}", async (int id, StockViewerContext dbContext) =>
        {
            User? user = await dbContext.Users.FindAsync(id);

            return user is null ? Results.NotFound() : Results.Ok(user.ToUserSummaryDto());
        })
        .WithName(GetUserEndpointName);

        // POST /users
        group.MapPost("/", async (CreateUserDto newUser, StockViewerContext dbContext) =>
        {
            User user = newUser.ToEntity();

            dbContext.Add(user);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetUserEndpointName, new {id = user.Id}, user.ToUserSummaryDto());
        });
        return group;
    }

    
}
