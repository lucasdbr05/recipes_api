namespace RecipesAPI.Entities;

public class Ingredient {
    public Ingredient(string name, int quantity, string measure)
    {
        Name = name;
        Quantity = quantity;
        Measure = measure;
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Quantity { get; set; }
    public string Measure { get; set; } = null!;
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;
}