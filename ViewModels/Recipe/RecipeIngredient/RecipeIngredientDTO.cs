namespace RecipesAPI.ViewModels;

public class CreateRecipeIngredientDTO
{
    public int IngredientId { get; set; }
    public decimal Quantity { get; set; }
}
public class UpdateRecipeIngredientDTO {
    public decimal Quantity { get; set; }
}

public class CreateOrUpdateRecipeIngredientDT0 : CreateRecipeIngredientDTO {
    public int? Id { get; set; } 
}