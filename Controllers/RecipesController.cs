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

    [HttpGet]
    public IActionResult GetAll() {
        var ingredients =  RecipeService.GetAll();

        return Ok(ingredients);
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id) {
        var recipe =  RecipeService.Get(id);

        return Ok(recipe);
    }

    [HttpPatch("{id:int}")]
    public IActionResult Patch(int id, UpdateRecipeViewModel data) {
        if (id != data.Id)
            throw new BadHttpRequestException("Id in the request doesn't correspond to in the body.");

        var recipe = RecipeService.Update(id, data);

        return Ok(recipe);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Remove(int id) {
        RecipeService.Remove(id);
 
        return Ok(id);
    }

    [HttpDelete("ingredient/{id:int}")]
    public IActionResult RemoveIngredient(int id) {
        RecipeService.RemoveIngredient(id);
 
        return Ok(id);
    }
}