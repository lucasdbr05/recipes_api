namespace RecipesAPI.Entities;

public class RecipeIngredient {
    public RecipeIngredient(int recipeId, int ingredientId, decimal quantity)
    {
        RecipeId = recipeId;
        IngredientId = ingredientId;
        Quantity = quantity;
    }

    public int RecipeId { get; set; }
    public int IngredientId { get; set; }
    public decimal Quantity { get; set; } 
    public Recipe Recipe { get; set; } = null!;
    public Ingredient Ingredient { get; set; } = null!;
}