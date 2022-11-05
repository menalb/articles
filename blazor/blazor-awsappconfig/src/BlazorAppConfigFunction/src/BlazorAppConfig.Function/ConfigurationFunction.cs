using System.Net;
using System.Net.Http.Json;
using Amazon.Lambda.APIGatewayEvents;
using BlazorAppConfig.Shared;

namespace BlazorAppConfig.Function;

internal class ConfigurationFunction
{
    private readonly HttpClient _configExtensionhttpClient;

    private readonly string _recipeConfigPath;

    public ConfigurationFunction(HttpClient configExtensionhttpClient, string recipeConfigPath)
    {
        _configExtensionhttpClient = configExtensionhttpClient ?? throw new ArgumentNullException(nameof(configExtensionhttpClient));
        _recipeConfigPath = recipeConfigPath ?? throw new ArgumentNullException(nameof(recipeConfigPath));
    }

    public async Task<APIGatewayProxyResponse> GetConfiguration()
    {
        var config = await RetrieveConfigurationFromExtension();

        string responseBody = "";
        if (config is not null)
        {
            var actualConfig = MapConfiguration(config);

            responseBody = System.Text.Json.JsonSerializer.Serialize(actualConfig);
        }

        return new APIGatewayProxyResponse
        {
            StatusCode = (int)HttpStatusCode.OK,
            Body = responseBody,
            Headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json" } ,
                {"Access-Control-Allow-Origin", "*"},
                {"Access-Control-Allow-Methods", "*"},
            }
        };
    }

    private FeaturesConfiguration MapConfiguration(FeaturesResponse feature)
    {
        return new FeaturesConfiguration(feature.WizardRecipeSteps, new(feature.RecipePagination.PageSize, feature.RecipePagination.Enabled));
    }

    private async Task<FeaturesResponse?> RetrieveConfigurationFromExtension()
    {
        var url = "http://localhost:2772";

        _configExtensionhttpClient.BaseAddress = new Uri(url);

        var response = await _configExtensionhttpClient.GetAsync(_recipeConfigPath);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<FeaturesResponse>();
        }

        return null;
    }
}

internal record PaginationAppConfigFeature(bool Enabled, int PageSize);
internal record FeaturesResponse(Feature WizardRecipeSteps, PaginationAppConfigFeature RecipePagination);
