using RecipesAPI.Entities;

namespace RecipesAPI.ViewModels;

public class DetailRecipeViewModel
{
    public DetailRecipeViewModel(int id, string name, string preparationMethod, ICollection<RecipeIngredient> recipeIngredients) 
    {   
        Id = id;
        Name = name;
        PreparationMethod = preparationMethod;
        RecipeIngredients = recipeIngredients;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string PreparationMethod { get; set; }
    public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
}