namespace RecipesAPI.ViewModels;

public class UpdateIngredientViewModel
{
    public UpdateIngredientViewModel(int id, string name, string unity) 
    {   
        Id = id;
        Name = name;
        Unity = unity;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Unity { get; set; }
}