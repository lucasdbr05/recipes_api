namespace RecipesAPI.ViewModels;

public class DetailIngredientViewModel
{
    public DetailIngredientViewModel(int id, string name, string unity) 
    {   
        Id = id;
        Name = name;
        Unity = unity;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Unity { get; set; }
}