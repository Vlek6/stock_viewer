// using directive to include the EntityFrameworkCore namespace, allowing us to use its features
using Microsoft.EntityFrameworkCore;
using StockViewer.Api.Entities;

// Define the namespace for the data layer of the StockViewer API
namespace StockViewer.Api.Data;

// Define the StockViewerContext class that inherits from DbContext, the base class for interacting with a database using Entity Framework
public class StockViewerContext(DbContextOptions<StockViewerContext> options) : DbContext(options)
{
    // Property to access and manage user entities in the database. This uses the DbSet<User> type suitable for CRUD operations.
    public DbSet<User> Users => Set<User>();

    // Property to access and manage stock entities in the database. Similar to Users, this DbSet<Stock> allows CRUD operations on the Stock entity.
    public DbSet<Stock> Stocks => Set<Stock>();
}
