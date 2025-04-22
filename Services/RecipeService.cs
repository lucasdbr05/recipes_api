using RecipesAPI.Contexts;

namespace RecipesAPI.Services;

public class RecipeService {
    private readonly APIDbContext _context;

    public RecipeService(APIDbContext dbContext) {
        _context = dbContext;
    }

}