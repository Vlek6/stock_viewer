// using directive to include the EntityFrameworkCore namespace, allowing us to use its features
using Microsoft.EntityFrameworkCore;
using StockViewer.Api.Entities;

// Define the namespace for the data layer of the StockViewer API
namespace StockViewer.Api.Data;



/// <summary>
/// Represents the database context for the StockViewer API.
/// </summary>
public class StockViewerContext(DbContextOptions<StockViewerContext> options) : DbContext(options)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StockViewerContext"/> class.
    /// </summary>
    /// <param name="options">The options to be used by the context.</param>
    public DbSet<User> Users => Set<User>();

    /// <summary>
    /// Provides access to manage Stock entities in the database.
    /// </summary>
    /// <remarks>
    /// This property allows CRUD (Create, Read, Update, Delete) operations on Stock entities.
    /// </remarks>
    public DbSet<Stock> Stocks => Set<Stock>();
}
