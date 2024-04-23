using StockViewer.Frontend.Clients;
using StockViewer.Frontend.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
var gamestoreUrl = builder.Configuration["GameStoreApiUrl"]??
    throw new Exception ("GameStoreApiUrl is not set");
builder.Services.AddHttpClient<GamesClient>(client => client.BaseAddress = new Uri(gamestoreUrl));
builder.Services.AddHttpClient<GenresClient>(client => client.BaseAddress = new Uri(gamestoreUrl));
builder.Services.AddSingleton<UsersClient>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
