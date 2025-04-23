namespace RecipesAPI.ViewModels;

public class UpdateRecipeViewModel {
    public UpdateRecipeViewModel(int id, string name, string preparationMethod, ICollection<CreateOrUpdateRecipeIngredientDT0> ingredients)
    {
        Id = id;
        Name = name;
        PreparationMethod = preparationMethod;
        Ingredients = ingredients;
    }

    public int Id { get; set; }
    public  string Name { get; set; }
    public string PreparationMethod { get; set; } 
    public ICollection<CreateOrUpdateRecipeIngredientDT0> Ingredients { get; set; }
}