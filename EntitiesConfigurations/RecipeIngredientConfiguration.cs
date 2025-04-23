using RecipesAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AeroGestDotnet.EntitiesConfiguration;

public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
{
    public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
    {
        builder.ToTable("RecipeIngredients");

        builder.HasKey(ri => ri.Id);
        
        builder.Property(ri => ri.Quantity)
            .IsRequired();

        builder.HasOne(ri => ri.Recipe)
            .WithMany(r => r.Ingredients)
            .HasForeignKey(ri => ri.RecipeId);
            
        builder.HasOne(ri => ri.Ingredient)
            .WithMany(i => i.Recipes)
            .HasForeignKey(ri => ri.IngredientId);
    }
}