// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using Amazon.CDK;
using Amazon.CDK.AWS.AppRunner;
using Amazon.CDK.AWS.IAM;
using AWS.Deploy.Recipes.CDK.Common;
using UGIAppRunner.Deployment.Configurations;
using Amazon.CDK.AWS.ECR;
using Amazon.CDK.AWS.ECS;

using CfnService = Amazon.CDK.AWS.AppRunner.CfnService;
using CfnServiceProps = Amazon.CDK.AWS.AppRunner.CfnServiceProps;
using Amazon.CDK.AWS.SSM;

namespace UGIAppRunner.Deployment
{
    public class AppStack : Stack
    {
        private readonly Configuration _configuration;

        internal AppStack(Construct scope, IDeployToolStackProps<Configuration> props)
            : base(scope, props.StackName, props)
        {
            _configuration = props.RecipeProps.Settings;

            // Setup callback for generated construct to provide access to customize CDK properties before creating constructs.
            CDKRecipeCustomizer<Recipe>.CustomizeCDKProps += CustomizeCDKProps;

            // Create custom CDK constructs here that might need to be referenced in the CustomizeCDKProps. For example if
            // creating a DynamoDB table construct and then later using the CDK construct reference in CustomizeCDKProps to
            // pass the table name as an environment variable to the container image.

            // Create the recipe defined CDK construct with all of its sub constructs.
            var generatedRecipe = new Recipe(this, props.RecipeProps);

            // Create additional CDK constructs here. The recipe's constructs can be accessed as properties on
            // the generatedRecipe variable.

            // set the connection string in Parameter Store if not already there
            var connectionString = new StringParameter(this, "UGIAppRunnerDatabaseConnectionString", new StringParameterProps
            {
                ParameterName = "/UGIAppRunner/ConnectionStrings/UGIAppRunnerDatabase",
                Type = ParameterType.STRING,
                Description = "SQL Server connection string",
                StringValue = "database connection string"
            });

            // Display connection string as output
            new CfnOutput(this, "SQLServerConnectionString", new CfnOutputProps
            {
                Value = connectionString.StringValue
            });

            var ugiVpcConnector = new CfnVpcConnector(this, "UGIAppRunnerVpcConnector", new CfnVpcConnectorProps
            {
                VpcConnectorName = "UGIAppRunnerConnector",                
                Subnets = new string[] { "subnet-1", "subnet-2" },
                SecurityGroups = new string[] { "security-group" }
            });

            new CfnOutput(this, "UGIAppRunnerVpcConnectorOut", new CfnOutputProps
            {
                Value = ugiVpcConnector.AttrVpcConnectorArn
            });

            var appRunner = generatedRecipe.AppRunnerService;

            if (appRunner != null)
            {
                if (appRunner.NetworkConfiguration == null)
                {
                    var egressConfig = new CfnService.EgressConfigurationProperty
                    {
                        EgressType = "VPC",
                        VpcConnectorArn = ugiVpcConnector.AttrVpcConnectorArn
                    };
                    var network = new CfnService.NetworkConfigurationProperty
                    {
                        EgressConfiguration = egressConfig
                    };

                    appRunner.NetworkConfiguration = network;
                }
            }
        }

        /// <summary>
        /// This method can be used to customize the properties for CDK constructs before creating the constructs.
        ///
        /// The pattern used in this method is to check to evnt.ResourceLogicalName to see if the CDK construct about to be created is one
        /// you want to customize. If so cast the evnt.Props object to the CDK properties object and make the appropriate settings.
        /// </summary>
        /// <param name="evnt"></param>
        private void CustomizeCDKProps(CustomizePropsEventArgs<Recipe> evnt)
        {
            // Example of how to customize the container image definition to include environment variables to the running applications.
            // 
            //if (string.Equals(evnt.ResourceLogicalName, nameof(evnt.Construct.AppRunnerService)))
            //{
            //    if (evnt.Props is CfnServiceProps props)
            //    {
            //        Console.WriteLine("Customizing AppRunner Service");
            //    }
            //}
        }
    }
}
