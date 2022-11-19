using Amazon.CDK.AWS.AppConfig;
using Constructs;

namespace BlazorAppConfigCdk
{
    internal class AppConfigBuilder
    {
        internal static (
            CfnConfigurationProfile configurationProfile,
            CfnEnvironment environment
            ) Build(Construct scope, CfnApplication app, string flagContent)
        {
            var appconfigConfigurationProfile =
                   new CfnConfigurationProfile(
                       scope,
                       "appconfigConfigurationProfile",
                       new CfnConfigurationProfileProps
                       {
                           ApplicationId = app.Ref,
                           LocationUri = "hosted",
                           Name = "RecipeAppConfigurationProfile",
                           Type = "AWS.AppConfig.FeatureFlags",
                       });

            var hostedConfigurationVersion =
                new CfnHostedConfigurationVersion
                (
                    scope,
                    "hostedConfigurationVersion",
                    new CfnHostedConfigurationVersionProps
                    {
                        ApplicationId = app.Ref,
                        ConfigurationProfileId = appconfigConfigurationProfile.Ref,
                        ContentType = "application/json",
                        Content = flagContent
                    });

            var appconfigEnv =
                new CfnEnvironment
                (
                    scope,
                    "appconfigEnv",
                    new CfnEnvironmentProps
                    {
                        ApplicationId = app.Ref,
                        Name = "Beta"
                    });

            var deploymentStrategy =
                new CfnDeploymentStrategy
                (
                    scope, "deploymentStrategy",
                    new CfnDeploymentStrategyProps
                    {
                        DeploymentDurationInMinutes = 0,
                        GrowthFactor = 100,
                        Name = "betaDeploymentStrategy",
                        ReplicateTo = "NONE",
                        FinalBakeTimeInMinutes = 0,
                    });

            var deployment =
                new CfnDeployment
                (
                    scope,
                    "InitialDeployment",
                    new CfnDeploymentProps
                    {
                        ApplicationId = app.Ref,
                        ConfigurationProfileId = appconfigConfigurationProfile.Ref,
                        ConfigurationVersion = hostedConfigurationVersion.Ref,
                        EnvironmentId = appconfigEnv.Ref,
                        DeploymentStrategyId = deploymentStrategy.Ref
                    });

            return (appconfigConfigurationProfile, appconfigEnv);
        }
    }
}
