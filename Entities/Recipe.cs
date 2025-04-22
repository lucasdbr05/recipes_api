namespace RecipesAPI.Entities;

public class Recipe {
    public Recipe(int id, string name, string preparationMethod)
    {
        Id = id;
        Name = name;
        PreparationMethod = preparationMethod;
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string PreparationMethod { get; set; } = null!;
    public ICollection<RecipeIngredient> Ingredients { get; set; } = null!;
}