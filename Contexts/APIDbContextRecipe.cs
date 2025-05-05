using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RecipesAPI.Contexts;

public class APIDbContextFactory : IDesignTimeDbContextFactory<APIDbContext>
{
    public APIDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<APIDbContext>();
        optionsBuilder.UseNpgsql("Host=database;Port=5432;Database=recipes;Username=postgres;Password=33647553");

        return new APIDbContext(optionsBuilder.Options);
    }
}
