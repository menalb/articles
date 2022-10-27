using BlazorAppConfig.Shared;
using System.Net.Http.Json;

namespace BlazorAppConfig.Web.Services;

public class AppConfigurationService
{
    private readonly HttpClient _http;

    public AppConfigurationService(HttpClient http)
    {
        _http = http ?? throw new ArgumentNullException(nameof(http));
    }

    public async Task<AppConfiguration> GetConfiguration()
    {
        var config = await _http.GetFromJsonAsync<FeaturesConfiguration>("config");
        if (config != null)
        {
            return new(config.StepsListWizard.Enabled, config.PagedRecipesList.Enabled, config.PagedRecipesList.PageSize);
        }
        return new (false,false,10);
    }    
}

public record AppConfiguration(bool IsStepsListWizardEnabled,bool IsPagedRecipesEnabled, int RecipesListPageSize);
