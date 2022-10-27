using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorAppConfig.Web;
using BlazorAppConfig.Web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration["Backend:FlagsApiUrl"] ?? throw new ArgumentNullException("Configuration"))
});

builder.Services.AddScoped<AppConfigurationService>();
builder.Services.AddSingleton<AppConfigurationStorageService>();
builder.Services.AddSingleton<RecipesQuery>();

var host = builder.Build();
var storage = host.Services.GetService<AppConfigurationStorageService>();
var service = host.Services.GetService<AppConfigurationService>();
if (service is not null && storage is not null)
{
    var config = await service.GetConfiguration();
    storage.Init(config);
}

await host.RunAsync();