namespace RecipesAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using RecipesAPI.Services;


[Route("api/ingredients")]
[ApiController]
public class IngredientsController : ControllerBase {
    private readonly IngredientService ingredientService;

    public IngredientsController(IngredientService ingredientService) {
        this.ingredientService = ingredientService;
    }

    
}