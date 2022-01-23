namespace PurchaseNexus.Server.Data.Configurations;

public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(100);

        builder.Property(t => t.Note)
            .HasMaxLength(300);

        // Navigation property, likely only set by EF
        builder.HasOne(x => x.List)
            .WithMany(x => x.Items);
    }
}
