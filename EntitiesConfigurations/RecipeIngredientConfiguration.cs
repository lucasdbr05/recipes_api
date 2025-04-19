using RecipesAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AeroGestDotnet.EntitiesConfiguration;

public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
{
    public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
    {
        builder.ToTable("RecipeIngredients");

        builder.Property(r => r.Quantity)
            .IsRequired();

        builder.HasOne(r => r.Recipe)
            .WithMany(r => r.Ingredients)
            .HasForeignKey(r => r.RecipeId);
            
        builder.HasOne(r => r.Ingredient)
            .WithMany(i => i.Recipes)
            .HasForeignKey(r => r.IngredientId);
    }
}