using System.Net;
using System.Net.Http.Json;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace BlazorAppConfigFunction;

public class Function
{
    private readonly string BlazorConfigPath = Environment.GetEnvironmentVariable("BLAZOR_CONFIG_PATH") 
        ?? throw new ArgumentException("BLAZOR_CONFIG_PATH");

    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
    {

        await Task.CompletedTask;

        var config = await GetConfiguration();

        string responseBody = "";
        if(config is not null)
        {
            var actualConfig = MapConfiguration(config);

            responseBody = System.Text.Json.JsonSerializer.Serialize(actualConfig);

        }

        var response = new APIGatewayProxyResponse
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

        return response;
    }

    private FeaturesConfiguration MapConfiguration(FeaturesResponse feature)
    {
        return new FeaturesConfiguration(feature.StepsListWizardComponent, new(feature.Pagination.Number, feature.Pagination.Enabled));
    }
    private record FeaturesConfiguration(Feature StepsListWizard, PaginationFeature PagedRecipesList);

    private async Task<FeaturesResponse?> GetConfiguration()
    {
        var url = "http://localhost:2772";

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(url);

            var response = await client.GetAsync(BlazorConfigPath);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<FeaturesResponse>();
            }
        }
        return null;
    }

    private record Feature(bool Enabled);    
    private record PaginationAppConfigFeature(bool Enabled, int Number);
    private record FeaturesResponse(Feature StepsListWizardComponent, PaginationAppConfigFeature Pagination);
    
    private record PaginationFeature(int PageSize, bool Enabled);
}
