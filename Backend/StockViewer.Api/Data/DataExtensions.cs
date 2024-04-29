using Microsoft.EntityFrameworkCore;

namespace StockViewer.Api.Data;


/// <summary>
/// Provides extension methods for database-related operations.
/// </summary>
public static class DataExtensions
{
    /// <summary>
    /// Asynchronously migrates the database associated with the web application.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    /// <returns>A task representing the asynchronous migration operation.</returns>
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<StockViewerContext>();
        await dbContext.Database.MigrateAsync();
    }
}
