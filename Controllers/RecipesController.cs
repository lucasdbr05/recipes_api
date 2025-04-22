namespace RecipesAPI.Controllers;
using RecipesAPI.Services;


public class RecipesController {
    private readonly RecipeService recipeService;

    public RecipesController(RecipeService recipeService) {
        this.recipeService = recipeService;
    }

    
}