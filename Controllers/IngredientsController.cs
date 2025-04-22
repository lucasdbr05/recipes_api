namespace RecipesAPI.Controllers;

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
    public DetailIngredientViewModel Create(CreateIngredientViewModel data) {
        return IngredientService.Create(data);
    }

    [HttpGet]
    public List<DetailIngredientViewModel> GetAll() {
        return IngredientService.GetAll();
    }

    [HttpGet("{id:int}")]
    public DetailIngredientViewModel Get(int id) {
        return IngredientService.Get(id);
    }
    
    [HttpPatch("{id:int}")]
    public DetailIngredientViewModel Patch(int id, UpdateIngredientViewModel data) {
        return IngredientService.Update(id, data);
    }

    [HttpDelete("{id:int}")]
    public int Remove(int id) {
        IngredientService.Remove(id);
        return id;
    }
    
}