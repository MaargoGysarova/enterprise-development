using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using PharmacyManagementSystem.Client;
using PharmacyManagementSystem.Client.Api;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Настройка HttpClient
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5001"),
    DefaultRequestHeaders = { { "Accept", "application/json" } }
});

// Регистрация API клиента как Scoped сервиса
builder.Services.AddScoped(sp =>
{
    var httpClient = sp.GetRequiredService<HttpClient>();
    return new Client(httpClient.BaseAddress!.ToString(), httpClient);
});

await builder.Build().RunAsync();
