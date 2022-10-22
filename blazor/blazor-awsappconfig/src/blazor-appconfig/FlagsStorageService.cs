using System.Net.Http.Json;

namespace blazor_appconfig.Services;

public class FlagsService
{
    private readonly HttpClient _http;

    public FlagsService(HttpClient http)
    {
        _http = http ?? throw new ArgumentNullException(nameof(http));
    }

    public async Task<IEnumerable<string>> GetFlags()
    {
        var flag = await _http.GetFromJsonAsync<FlagResponse>("mansions");
        if (flag != null && flag.Enabled)
        {
            return new List<string> { nameof(Components.StepsListWizardComponent) };
        }
        return new List<string>();
    }

    public record FlagResponse(bool Enabled);
}

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
    {
        return Flags.Any(f=>f == nameof(Components.StepsListWizardComponent));
    }
}
