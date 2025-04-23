using Microsoft.EntityFrameworkCore;
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


    public List<DetailRecipeViewModel> GetAll() {
        var recipes = _context
            .Recipes
            .Include(r => r.Ingredients)
            .Select(
                recipe =>  new DetailRecipeViewModel(
                        recipe.Id,
                        recipe.Name,
                        recipe.PreparationMethod,
                        recipe.Ingredients
                    )
            )
            .ToList();   

        return recipes;    
    }

    public DetailRecipeViewModel Get(int Id) {
        var recipe = _context.Recipes
            .Include(r => r.Ingredients)
            .Single(i => i.Id == Id);       
        
        return new DetailRecipeViewModel(
            recipe.Id,
            recipe.Name,
            recipe.PreparationMethod,
            recipe.Ingredients
        );
    }  

    public DetailRecipeViewModel Update(
        int id, 
        UpdateRecipeViewModel data
    ) {
        var recipe = _context.Recipes.SingleOrDefault(i => i.Id == id);

        if (recipe == null) {
            throw new KeyNotFoundException($"Recipe with ID {id} not found.");
        }

        recipe.Name = data.Name;
        recipe.PreparationMethod = data.PreparationMethod;

        _context.Recipes.Update(recipe);
        _context.SaveChanges();

        return new DetailRecipeViewModel(
            recipe.Id,
            recipe.Name,
            recipe.PreparationMethod,
            recipe.Ingredients
        );
    }

    public void Remove(int id) {
        var recipe = _context.Recipes
            .SingleOrDefault(recipe => recipe.Id == id);

        if (recipe == null) {
            throw new BadHttpRequestException($"Recipe with ID {id} not found.");
        }

        _context.Recipes.Remove(recipe);
        _context.SaveChanges();       
    }
}