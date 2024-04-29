using StockViewer.Api;
using StockViewer.Api.Data;
using StockViewer.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("StockViewer");
builder.Services.AddSqlite<StockViewerContext>(connString);

var app = builder.Build();

app.MapUsersEndpoints();
app.MapStocksEndpoints();

await app.MigrateDbAsync();
app.Run();
