namespace RecipesAPI.ViewModels;

public class CreateRecipeIngredientDTO
{
    public int IngredientId { get; set; }
    public decimal Quantity { get; set; }
}
public class UpdateRecipeIngredientDTO : CreateRecipeIngredientDTO;