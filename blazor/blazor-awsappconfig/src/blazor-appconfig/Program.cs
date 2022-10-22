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

builder.Services.AddSingleton<RecipesQuery>();
builder.Services.AddScoped<FlagsStorageService>();

await builder.Build().RunAsync();