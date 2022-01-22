namespace PurchaseNexus.Server.Data.Configurations;

public class RecipeStepConfiguration : IEntityTypeConfiguration<RecipeStep>
{
    public void Configure(EntityTypeBuilder<RecipeStep> builder)
    {
        builder.Property(t => t.Description)
            .HasMaxLength(150);
    }
}

