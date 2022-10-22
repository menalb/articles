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
        var flags = await _http.GetFromJsonAsync<IEnumerable<FlagResponse>>("flags");
        if (flags != null)
        {
            return flags.Select(f => f.Name);
        }
        return new List<string>();
    }
    record FlagResponse(string Name);
}
