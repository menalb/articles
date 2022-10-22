namespace blazor_appconfig.Services;

public class FlagsStorageService
{
    private IEnumerable<string> Flags = new List<string>();

    public void Init(IEnumerable<string> flags)
    {
        if (flags != null)
        {
            Flags = flags;
        }
    }

    public bool IsRecipeStepsWizardEnabled()
     => Flags.Any(f => f == nameof(Components.StepsListWizardComponent));
}
