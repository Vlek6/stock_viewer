using StockViewer.Api.Data;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("StockViewer");
builder.Services.AddSqlite<StockViewerContext>(connString);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

await app.MigrateDbAsync();

app.Run();
