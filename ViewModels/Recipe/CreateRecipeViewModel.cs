namespace RecipesAPI.ViewModels;

public class CreateRecipeViewModel
{
    public CreateRecipeViewModel(string name, string preparationMethod, ICollection<CreateRecipeIngredientDTO> recipeIngredients) 
    {   
        Name = name;
        PreparationMethod = preparationMethod;
        RecipeIngredients = recipeIngredients;
    }

    public string Name { get; set; }
    public string PreparationMethod { get; set; }
    public ICollection<CreateRecipeIngredientDTO> RecipeIngredients  { get; set; }
}