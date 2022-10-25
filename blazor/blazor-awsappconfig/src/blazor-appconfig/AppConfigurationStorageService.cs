namespace blazor_appconfig.Services;

public class AppConfigurationStorageService
{
    public void Init(AppConfiguration config)
    {
        if (config != null)
        {
            Configuration = config;
        }
    }

    public AppConfiguration Configuration { get; private set; } = new AppConfiguration(10, new List<string>());

    public bool IsRecipeStepsWizardEnabled()
     => Configuration.Features.Any(f => f == nameof(Components.StepsListWizardComponent));
    public bool IsPaginationEnabled()
     => Configuration.Features.Any(f => f == "Pagination");
}
