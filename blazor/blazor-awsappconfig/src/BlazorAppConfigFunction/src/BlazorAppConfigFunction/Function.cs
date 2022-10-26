using System.Net;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace BlazorAppConfigFunction;

public class Function
{
    
    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
    {

        await System.Threading.Tasks.Task.CompletedTask;

        var response = new APIGatewayProxyResponse
        {
            StatusCode = (int)HttpStatusCode.OK,
            Body="Hello!",
            Headers = new Dictionary<string, string>
                {
                     { "Content-Type", "application/json" } ,
                     {"Access-Control-Allow-Origin", "*"},
                     {"Access-Control-Allow-Methods", "*"},
                }
        };

        return response;
    }
}
