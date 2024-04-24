using StockViewer.Frontend.Clients;
using StockViewer.Frontend.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
var stockApiUrl = builder.Configuration["stockApiUrl"]??
    throw new Exception ("stockApiUrl is not set");
var ApiKey = builder.Configuration["APIkey"];

// builder.Services.AddHttpClient<GamesClient>(client);
builder.Services.AddHttpClient<GenresClient>(client => {
        client.BaseAddress = new Uri(stockApiUrl); 
        client.DefaultRequestHeaders.Add("api-key", ApiKey);
        }
    );
builder.Services.AddHttpClient<StockClient>(client => {
        client.BaseAddress = new Uri(stockApiUrl); 
        client.DefaultRequestHeaders.Add("api-key", ApiKey);
        }
    );
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
