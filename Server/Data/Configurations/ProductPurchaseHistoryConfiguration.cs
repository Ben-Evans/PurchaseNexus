namespace PurchaseNexus.Server.Data.Configurations;

public class ProductPurchaseHistoryConfiguration : IEntityTypeConfiguration<ProductPurchaseHistory>
{
    public void Configure(EntityTypeBuilder<ProductPurchaseHistory> builder)
    {
        builder.Property(t => t.PurchaseDate)
            .HasPrecision(0);
    }
}
