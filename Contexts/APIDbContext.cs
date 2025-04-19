using RecipesAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace RecipesAPI.Contexts;

public class APIDbContext : DbContext {
    public APIDbContext(DbContextOptions<APIDbContext> options) 
        : base(options) {}

    public DbSet<Recipe> Recipes => Set<Recipe>();
    public DbSet<RecipeIngredient> RecipeIngredients => Set<RecipeIngredient>();
    public DbSet<Ingredient> Ingredients => Set<Ingredient>();
}