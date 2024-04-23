using Microsoft.EntityFrameworkCore;
using StockViewer.Api.Data;

namespace StockViewer.Api.Endpoints;

public static class UsersEndpoints
{
    public static RouteGroupBuilder MapUsersEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("users").WithParameterValidation();

        //GET /users
        group.MapGet("/", async (StockViewerContext dbContext) =>
            await dbContext.Users.AsNoTracking().ToListAsync()
        );

        return group;
    }
}
