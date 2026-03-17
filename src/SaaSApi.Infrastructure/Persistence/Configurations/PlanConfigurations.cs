using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PlanConfigurations : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.ToTable("plans");

        builder.Property(p => p.Id)
            .HasColumnName("id");


        builder.Property(p => p.Name)
            .HasMaxLength(100)
            .HasColumnName("name")
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(256)
            .HasColumnName("description");

        builder.OwnsOne(p => p.Price, money =>
        {
            money.Property(m => m.Amount).HasColumnName("price_amount");
            money.Property(m => m.Currency).HasColumnName("price_currency");
        });

        builder.Property(p => p.BillingCycle)
            .HasColumnName("billing_cycle")
            .HasConversion<string>()
            .IsRequired();

        builder.Property(p => p.IsActive)
            .HasColumnName("is_active")
            .IsRequired();
    }
}