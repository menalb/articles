using System.Net.Http.Json;

namespace blazor_appconfig.Services;

public class AppConfigurationService
{
    private readonly HttpClient _http;

    public AppConfigurationService(HttpClient http)
    {
        _http = http ?? throw new ArgumentNullException(nameof(http));
    }

    public async Task<AppConfiguration> GetConfiguration()
    {
        var config = await _http.GetFromJsonAsync<AppConfigurationResponse>("flags");
        if (config != null)
        {
            return new(config.StepsListWizard.Enabled, config.PagedRecipesList.Enabled, config.PagedRecipesList.PageSize);
        }
        return new (false,false,10);
    }
    record FeatureResponse(string Name);
    record AppConfigurationResponse(PagedRecipesList PagedRecipesList, Feature StepsListWizard);
    record PagedRecipesList(int PageSize, bool Enabled) : Feature(Enabled);
    record Feature(bool Enabled);
}

public record AppConfiguration(bool IsStepsListWizardEnabled,bool IsPagedRecipesEnabled, int RecipesListPageSize);
