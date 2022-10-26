namespace BlazorAppConfigWeb.Services;

public class RecipesQuery
{
    public async Task<IEnumerable<Recipe>> GetAll()
        => await Task.FromResult(DB.Recipes);

    public async Task<Recipe> Get(int recipeId)
        => await Task.FromResult(DB.Recipes.Single(r => r.Id == recipeId));

}