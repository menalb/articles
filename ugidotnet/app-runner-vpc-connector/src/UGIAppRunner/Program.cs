using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using UGIAppRunner.Areas.Identity;
using UGIAppRunner.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddSystemsManager("/UGIAppRunner");

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("UGIAppRunnerDatabase");

builder.Services.AddDataProtection().PersistKeysToAWSSystemsManager("/UGIAppRunner/DataProtection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    try
    {
        var context = serviceProvider.GetService<ApplicationDbContext>();

        if (context != null)
        {
            context.Database.EnsureCreated();

            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
            if (userManager != null)
            {
                var user = new IdentityUser { UserName = "AliceSmith@email.com", Email = "AliceSmith@email.com", EmailConfirmed = true };

                var exists = (await userManager.FindByEmailAsync(user.UserName)) != null;

                if (!exists)
                {
                    var result = await userManager.CreateAsync(user, "Pass123$");
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                }
            }
        }
    }
    catch (Exception ex)
    {
        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

app.Run();

