using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RecipesAPI.Contexts;

public class APIDbContextFactory : IDesignTimeDbContextFactory<APIDbContext>
{
    public APIDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<APIDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=recipes;Username=postgres;Password=postgres");

        return new APIDbContext(optionsBuilder.Options);
    }
}
