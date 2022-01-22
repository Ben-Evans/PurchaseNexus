namespace PurchaseNexus.Server.Data.Configurations;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.Property(t => t.SourceUrl)
            .HasMaxLength(150);

        builder.Property(t => t.ServerImagePath)
            .HasMaxLength(80);
    }
}

