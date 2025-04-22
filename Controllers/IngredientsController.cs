namespace RecipesAPI.Controllers;
using RecipesAPI.Services;


public class IngredientsController {
    private readonly IngredientService ingredientService;

    public IngredientsController(IngredientService ingredientService) {
        this.ingredientService = ingredientService;
    }

    
}