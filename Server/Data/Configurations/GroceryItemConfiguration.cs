namespace PurchaseNexus.Server.Data.Configurations;

public class GroceryItemConfiguration : IEntityTypeConfiguration<GroceryItem>
{
    public void Configure(EntityTypeBuilder<GroceryItem> builder)
    {
        builder.Property(t => t.ExpiryDate)
            .HasPrecision(0);
    }
}

