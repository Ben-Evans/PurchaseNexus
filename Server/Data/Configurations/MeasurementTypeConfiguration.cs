namespace PurchaseNexus.Server.Data.Configurations;

public class MeasurementTypeConfiguration : IEntityTypeConfiguration<MeasurementType>
{
    public void Configure(EntityTypeBuilder<MeasurementType> builder)
    {
        builder.Property(t => t.Id)
            .ValueGeneratedNever();
    }
}
