using System.Net;
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