namespace RecipesAPI.Entities;

public class Recipe {
    public Recipe(int id, string name, string preparationMethod, ICollection<RecipeIngredient> ingredients)
    {
        Id = id;
        Name = name;
        PreparationMethod = preparationMethod;
        Ingredients = ingredients;
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string PreparationMethod { get; set; } = null!;
    public ICollection<RecipeIngredient> Ingredients { get; set; } = null!;
}