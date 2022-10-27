namespace BlazorAppConfig.Web.Services;

public class AppConfigurationStorageService
{
    public void Init(AppConfiguration config)
    {
        if (config != null)
        {
            FeaturesConfiguration = config;
        }
    }

    public AppConfiguration FeaturesConfiguration { get; private set; } = new AppConfiguration(false, false, 10);
}