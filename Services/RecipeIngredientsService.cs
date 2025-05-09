using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipesAPI.Contexts;
using RecipesAPI.Entities;
using RecipesAPI.ViewModels;

namespace RecipesAPI.Services;

public class RecipeIngredientService {
    private readonly APIDbContext _context;

    public RecipeIngredientService(APIDbContext dbContext) {
        _context = dbContext;
    }
    
    public RecipeIngredient Create(
        int recipeId, 
        CreateRecipeIngredientDTO data
    ) {
        var recipeIngredient = new RecipeIngredient (
            recipeId,
            data.IngredientId,
            data.Quantity
        );

        _context.RecipeIngredients.Add(recipeIngredient);

        return recipeIngredient;
    }

    public ICollection<RecipeIngredient> CreateMany(
        int recipeId,
        ICollection<CreateRecipeIngredientDTO> data
    ) {
        var recipeIngredients = data
            .Select(recipeIngredient => new RecipeIngredient (
                recipeId,
                recipeIngredient.IngredientId,
                recipeIngredient.Quantity
            )).ToList();

        _context.RecipeIngredients.AddRange(recipeIngredients);

        return recipeIngredients;
    }

    public RecipeIngredient Update(
        int id, 
        UpdateRecipeIngredientDTO data
    ) {
        var recipeIngredient = _context.RecipeIngredients
            .FirstOrDefault(ri => ri.Id == id);

        if (recipeIngredient == null) {
            throw new KeyNotFoundException($"Recipe ingredient with ID {id} not found.");
        }

        recipeIngredient.Quantity = data.Quantity;

        _context.RecipeIngredients.Update(recipeIngredient);
        _context.SaveChanges();

        return recipeIngredient;
    }

    public ICollection<RecipeIngredient> CreteOrUpdateMany(
        int recipeId, 
        ICollection<CreateOrUpdateRecipeIngredientDT0> data 
    ) {
        var recipeIngredients = 
            data.Select(ri => {
                if(ri.Id != null) {
                    UpdateRecipeIngredientDTO ingredientNewData = new UpdateRecipeIngredientDTO();
                    ingredientNewData.Quantity = ri.Quantity;
                    return Update(
                            ri.Id ?? 0, 
                            ingredientNewData
                        );            
                } else {
                    CreateRecipeIngredientDTO ingredientNewData = new CreateRecipeIngredientDTO();
                    ingredientNewData.IngredientId = ri.IngredientId;
                    ingredientNewData.Quantity = ri.Quantity;
                    
                    return Create(
                        recipeId,
                        ingredientNewData
                    );
                }
            })
            .ToList();

        return recipeIngredients;
    }

    public void Remove(int id) {
        var recipeIngredient = _context.RecipeIngredients
            .FirstOrDefault(ri => ri.Id == id);

        if (recipeIngredient == null) {
            throw new KeyNotFoundException($"Recipe ingredient with ID {id} not found.");
        }

        _context.RecipeIngredients.Remove(recipeIngredient);
        _context.SaveChanges();
    }
}