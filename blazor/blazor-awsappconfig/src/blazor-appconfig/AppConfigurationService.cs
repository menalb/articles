using System.Net.Http.Json;

namespace blazor_appconfig.Services;

public class AppConfigurationService
{
    private readonly HttpClient _http;

    public AppConfigurationService(HttpClient http)
    {
        _http = http ?? throw new ArgumentNullException(nameof(http));
    }

    public async Task<AppConfiguration> GetConfiguration()
    {
        var config = await _http.GetFromJsonAsync<AppConfigurationResponse>("flags");
        if (config != null)
        {
            return new(config.PageSize, config.Features.Select(f =>f.Name));
        }
        return new (10,new List<string>());
    }
    record FeatureResponse(string Name);

    record AppConfigurationResponse(int PageSize, IEnumerable<FeatureResponse> Features);
}

public record AppConfiguration(int PageSize, IEnumerable<string> Features);
