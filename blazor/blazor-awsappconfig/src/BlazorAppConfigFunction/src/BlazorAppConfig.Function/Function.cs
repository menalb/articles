using System.Net;
using System.Net.Http.Json;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using BlazorAppConfig.Shared;
using Microsoft.Extensions.DependencyInjection;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace BlazorAppConfig.Function;

public class Function
{
    private ServiceCollection _serviceCollection;

    private readonly string ConfigPath = Environment.GetEnvironmentVariable("RECIPE_CONFIG_PATH")
        ?? throw new ArgumentException("RECIPE_CONFIG_PATH");

    public Function()
    {
        ConfigureServices();
    }

    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
    {

        using (ServiceProvider serviceProvider = _serviceCollection.BuildServiceProvider())
        {
            var service = serviceProvider.GetService<ConfigurationFunction>();
            if (service is not null)
            {
                return await service.GetConfiguration();
            }

            return new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Body = "",
                Headers = new Dictionary<string, string>
                {
                    { "Content-Type", "application/json" } ,
                    {"Access-Control-Allow-Origin", "*"},
                    {"Access-Control-Allow-Methods", "*"},
                }
            };
        }
    }

    private void ConfigureServices()
    {
        _serviceCollection = new ServiceCollection();
        _serviceCollection.AddTransient<HttpClient>();
        _serviceCollection.AddTransient<ConfigurationFunction>(ctx => new(ctx.GetService<HttpClient>(), ConfigPath));
    }
}
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