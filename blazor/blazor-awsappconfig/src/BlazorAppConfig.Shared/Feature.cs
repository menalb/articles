namespace BlazorAppConfig.Shared
{
    public record Feature(bool Enabled);
    public record FeaturesConfiguration(Feature StepsListWizard, PaginationFeature PagedRecipesList);
    public record PaginationFeature(int PageSize, bool Enabled);
}