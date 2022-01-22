namespace PurchaseNexus.Server.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(t => t.Url)
            .HasMaxLength(150);

        builder.Property(t => t.Bardcode)
            .HasMaxLength(13);
    }
}

