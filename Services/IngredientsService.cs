using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipesAPI.Contexts;
using RecipesAPI.Entities;
using RecipesAPI.ViewModels;

namespace RecipesAPI.Services;

public class IngredientService {
    private readonly APIDbContext _context;

    public IngredientService(APIDbContext dbContext) {
        _context = dbContext;
    }
    

    public DetailIngredientViewModel Create(CreateIngredientViewModel data) {
        var ingredient = new Ingredient(
            data.Name,
            data.Unity
        );

        _context.Add(ingredient);
        _context.SaveChanges(); 

        return new DetailIngredientViewModel(
            ingredient.Id, 
            ingredient.Name, 
            ingredient.Unity
        );
    }

    public List<DetailIngredientViewModel> GetAll() {
        var ingredients = _context.Ingredients
            .ToList()
            .Select(
                ingredient =>  new DetailIngredientViewModel(
                        ingredient.Id,
                        ingredient.Name,
                        ingredient.Unity
                    )
            )
            .ToList();   

        return ingredients;    
    }  
    public DetailIngredientViewModel Get(int Id) {
        var ingredient = _context.Ingredients.Single(i => i.Id == Id);       
        
        return new DetailIngredientViewModel(
            ingredient.Id,
            ingredient.Name,
            ingredient.Unity
        );
    }  

    public DetailIngredientViewModel Update(
        int id, 
        UpdateIngredientViewModel data
    ) {
        var ingredient = _context.Ingredients.SingleOrDefault(i => i.Id == id);

        if (ingredient == null) {
            throw new KeyNotFoundException($"Ingredient with ID {id} not found.");
        }

        ingredient.Name = data.Name;
        ingredient.Unity = data.Unity;

        _context.Ingredients.Update(ingredient);
        _context.SaveChanges();

        return new DetailIngredientViewModel(
            ingredient.Id,
            ingredient.Name,
            ingredient.Unity
        );
    }

    public void Remove(int id) {
        var ingredient = _context.Ingredients
            .SingleOrDefault(ingredient => ingredient.Id == id);

        if (ingredient == null) {
            throw new BadHttpRequestException($"Ingredient with ID {id} not found.");
        }

        _context.Ingredients.Remove(ingredient);
        _context.SaveChanges();       
    }
}