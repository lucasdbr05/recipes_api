namespace RecipesAPI.Entities;

public class Ingredient {
    public Ingredient(string name, string unity)
    {
        Name = name;
        Unity = unity;
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Unity { get; set; } = null!;
    public ICollection<RecipeIngredient> Recipes { get; set; } = null!;
}