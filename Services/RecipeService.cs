using RecipesAPI.Contexts;
using RecipesAPI.Entities;
using RecipesAPI.ViewModels;

namespace RecipesAPI.Services;

public class RecipeService {
    private readonly APIDbContext _context;
    private readonly RecipeIngredientService RecipeIngredientService;
    public RecipeService(
        APIDbContext dbContext, 
        RecipeIngredientService recipeIngredientService
    ) {
        _context = dbContext;
        RecipeIngredientService = recipeIngredientService;
    }

    public DetailRecipeViewModel Create(CreateRecipeViewModel data) {
        using var transaction = _context.Database.BeginTransaction();

        try {
            var recipe = new Recipe(
                data.Name,
                data.PreparationMethod
            );

            _context.Add(recipe);
            _context.SaveChanges(); 

            var recipeIngredients = 
                RecipeIngredientService.CreateMany(recipe.Id, data.RecipeIngredients);
            _context.SaveChanges(); 

            transaction.Commit();
            return new DetailRecipeViewModel(
                recipe.Id, 
                recipe.Name, 
                recipe.PreparationMethod,
                recipeIngredients
            );
        } catch {
            transaction.Rollback();
            throw new BadHttpRequestException("Error on create recipe");
        }
        
    } 

}