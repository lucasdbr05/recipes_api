namespace RecipesAPI.ViewModels;

public class CreateIngredientViewModel
{
    public CreateIngredientViewModel(string name, string unity) 
    {   
        Name = name;
        Unity = unity;
    }

    public string Name { get; set; }
    public string Unity { get; set; }
}