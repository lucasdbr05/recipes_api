namespace RecipesAPI.Entities;

public class Recipe {


    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string PreparationMethod { get; set; } = null!;
    public ICollection<Ingredient> Ingredients { get; set; } = null!;

}