using RecipesAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AeroGestDotnet.EntitiesConfiguration;

public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.ToTable("Ingredients");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Name)
            .IsRequired();
        
        builder.Property(i => i.Unity)
            .IsRequired();
    }
}