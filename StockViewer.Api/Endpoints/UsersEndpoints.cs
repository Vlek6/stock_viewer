using Microsoft.EntityFrameworkCore;
using StockViewer.Api.Data;
using StockViewer.Api.Entities;

namespace StockViewer.Api.Endpoints;

public static class UsersEndpoints
{
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
        });


        return group;
    }

    
}
