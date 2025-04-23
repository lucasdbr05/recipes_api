using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using RecipesAPI.Services;
using RecipesAPI.ViewModels;

namespace RecipesAPI.Controllers;

[Route("api/recipes")]
[ApiController]
public class RecipesController : ControllerBase {
    private readonly RecipeService RecipeService;

    public RecipesController(RecipeService recipeService) {
        RecipeService = recipeService;
    }

    [HttpPost]
    public IActionResult Create(CreateRecipeViewModel data) {
        var recipe = RecipeService.Create(data);
        return Ok(recipe);
    }
}