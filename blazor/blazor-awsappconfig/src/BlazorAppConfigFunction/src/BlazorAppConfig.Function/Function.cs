using System.Net;
using System.Net.Http.Json;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using BlazorAppConfig.Shared;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace BlazorAppConfig.Function;

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
        var config = await GetConfiguration();

        string responseBody = "";
        if(config is not null)
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
        return new FeaturesConfiguration(feature.StepsListWizardComponent, new(feature.Pagination.Number, feature.Pagination.Enabled));
    }    

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
    
    private record PaginationAppConfigFeature(bool Enabled, int Number);
    private record FeaturesResponse(Feature StepsListWizardComponent, PaginationAppConfigFeature Pagination);       
}
