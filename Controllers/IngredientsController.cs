namespace RecipesAPI.Controllers;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RecipesAPI.Services;
using RecipesAPI.ViewModels;

[Route("api/ingredients")]
[ApiController]
public class IngredientsController : ControllerBase {
    private readonly IngredientService IngredientService;

    public IngredientsController(IngredientService ingredientService) {
        IngredientService = ingredientService;
    }

    [HttpPost]
    public IActionResult Create(CreateIngredientViewModel data) {
        var ingredient =  IngredientService.Create(data);
        return Ok(ingredient);
    }

    [HttpGet]
    public IActionResult GetAll() {
        var ingredients =  IngredientService.GetAll();

        return Ok(ingredients);
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id) {
        var ingredient =  IngredientService.Get(id);
        return Ok(ingredient);
    }

    [HttpPatch("{id:int}")]
    public IActionResult Patch(int id, UpdateIngredientViewModel data) {
        if (id != data.Id)
            throw new BadHttpRequestException("Id in the request doesn't correspond to in the body.");

        var ingredient = IngredientService.Update(id, data);

        return Ok(ingredient);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Remove(int id) {
        IngredientService.Remove(id);
        return Ok(id);
    }
    
}