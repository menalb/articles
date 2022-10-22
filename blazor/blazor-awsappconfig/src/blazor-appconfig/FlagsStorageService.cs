using System.Net.Http.Json;

namespace blazor_appconfig.Services;

public class FlagsStorageService
{
    private readonly HttpClient _http;

    private List<FlagResponse> Flags = new();

    public FlagsStorageService(HttpClient http)
    {
        _http = http ?? throw new ArgumentNullException(nameof(http));
    }

    public async Task Init()
    {
        var flag = await _http.GetFromJsonAsync<FlagResponse>("mansions");
        if (flag != null)
        {
            Flags = new List<FlagResponse> { flag };
        }
    }

    public bool IsRecipeStepsWizardEnabled()
    {
        return Flags.Any();
    }

    record FlagResponse(bool Enabled);
}