using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using blazor_appconfig;
using blazor_appconfig.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration["Backend:FlagsApiUrl"] ?? throw new ArgumentNullException("Configuration"))
});

builder.Services.AddScoped<FlagsService>();
builder.Services.AddSingleton<FlagsStorageService>();
builder.Services.AddSingleton<RecipesQuery>();

var host = builder.Build();
var flagStorage = host.Services.GetService<FlagsStorageService>();
var flagService = host.Services.GetService<FlagsService>();
if (flagService is not null && flagStorage is not null)
{
    flagStorage.Init(await flagService.GetFlags());
}

await host.RunAsync();