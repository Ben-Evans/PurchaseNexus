namespace PurchaseNexus.Server.Data.Configurations;

public class StoreConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.Property(t => t.Url)
            .HasMaxLength(100);
    }
}

