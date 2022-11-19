using Amazon.CDK;
using Amazon.CDK.AWS.AppConfig;
using Amazon.CDK.AWS.Lambda;
using Amazon.CDK.AWS.Apigatewayv2.Alpha;
using Amazon.CDK.AWS.Apigatewayv2.Integrations.Alpha;
using Constructs;
using System.Collections.Generic;

namespace BlazorAppConfigCdk
{
    public class BlazorAppConfigCdkStack : Stack
    {
        internal BlazorAppConfigCdkStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            // The code that defines your stack goes here

            var appConfigExtensionArn = new CfnParameter(
              this,
              "appConfigExtensionArn",
              new CfnParameterProps { Type = "String" }
              );

            var APPCONFIG_EXTENSION_ARN = appConfigExtensionArn.ValueAsString;

            var appconfigApplication =
              new CfnApplication(
                  this,
                  "appconfigApplication",
                  new CfnApplicationProps
                  {
                      Name = "RecipeApplication"
                  });


            var (configurationProfile, environment) = AppConfigBuilder.Build(
                this,
                appconfigApplication,
                GetFlagContent()
                );            

            var assetOptions = new AssetCode("..\\..\\BlazorAppConfigFunction\\src\\BlazorAppConfig.Function\\bin\\Debug\\net6.0\\");

            var checkFeatureFlagStatusLambda = new Function(this, "CheckFeatureFlagStatusLambda",
                        new FunctionProps
                        {
                            Runtime = new Runtime("dotnet6"),
                            Code = assetOptions,
                            Handler = "BlazorAppConfig.Function::BlazorAppConfig.Function.Function::FunctionHandler",
                            MemorySize = 256,
                            Timeout = Duration.Seconds(30),
                            Environment = new Dictionary<string, string>
                            {
                                {
                                    "RECIPE_CONFIG_PATH",
                                    $"/applications/{appconfigApplication.Ref}/environments/{environment.Ref}/configurations/{configurationProfile.Ref}"
                                },
                            }
                        });

            checkFeatureFlagStatusLambda.AddLayers(
                LayerVersion.FromLayerVersionArn(this, "AppConfigExtension", APPCONFIG_EXTENSION_ARN)
                );

            checkFeatureFlagStatusLambda.Role.AttachInlinePolicy(
               new Amazon.CDK.AWS.IAM.Policy(this, "additionalPermissionsForAppConfig",
               new Amazon.CDK.AWS.IAM.PolicyProps
               {
                   Statements = new Amazon.CDK.AWS.IAM.PolicyStatement[]
                   {
                    new Amazon.CDK.AWS.IAM.PolicyStatement(new Amazon.CDK.AWS.IAM.PolicyStatementProps
                    {
                        Actions = new string[] { "appconfig:StartConfigurationSession", "appconfig:GetLatestConfiguration" },
                        Resources = new string[]
                        {
                            Fn.Sub(
                                "arn:aws:appconfig:${AWS::Region}:${AWS::AccountId}:application/${application}/environment/${environment}/configuration/${configurationProfile}",
                                new Dictionary<string,string>{  
                                    {"application",appconfigApplication.Ref } ,
                                    {"environment",environment.Ref },
                                    {"configurationProfile",configurationProfile.Ref }
                                })
                        }
                    })
                   }
               }));

            
            var httpApi = new HttpApi(this, "RecipeHttpApiConfig");
            httpApi.AddRoutes(new AddRoutesOptions
            {
                Path = "/config",
                Methods = new Amazon.CDK.AWS.Apigatewayv2.Alpha.HttpMethod[] { Amazon.CDK.AWS.Apigatewayv2.Alpha.HttpMethod.GET },
                Integration = new HttpLambdaIntegration("appconfigLambdaHttpApiIntegration", checkFeatureFlagStatusLambda)
            });

            new CfnOutput(this, "Environment", new CfnOutputProps
            {
                ExportName = "appconfigEnvironment",
                Value = environment.Name
            });

            new CfnOutput(this, "HttpApiUrl", new CfnOutputProps
            {
                ExportName = "appconfigAPIEndpoint",
                Value = httpApi.Url
            });
        }

        private static string GetFlagContent()
        => System.Text.Json.JsonSerializer.Serialize(new
        {
            version = "1",
            flags = new
            {
                recipePagination = new
                {
                    name = "RecipePagination",
                    attributes = new
                    {
                        pageSize = new
                        {
                            constraints = new
                            {
                                type = "number",
                                required = true,
                                minimum = 5,
                                maximum = 10
                            }
                        }
                    }
                },
                wizardRecipeSteps = new
                {
                    name = "WizardRecipeSteps"
                }
            },
            values = new
            {
                recipePagination = new
                {
                    enabled = true,
                    pageSize = 5
                },
                wizardRecipeSteps = new
                {
                    enabled = true
                }
            }
        });

    }
}

