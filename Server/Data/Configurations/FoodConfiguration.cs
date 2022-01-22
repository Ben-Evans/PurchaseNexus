namespace PurchaseNexus.Server.Data.Configurations;

public class FoodConfiguration : IEntityTypeConfiguration<Food>
{
    public void Configure(EntityTypeBuilder<Food> builder)
    {
        builder.Property(t => t.ExpiryDate)
            .HasPrecision(0);

        builder.Ignore(x => x.ToDelete);
    }
}

