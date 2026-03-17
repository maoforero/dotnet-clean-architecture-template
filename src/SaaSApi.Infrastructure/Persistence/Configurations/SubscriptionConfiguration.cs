using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaaSApi.Domain;

public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.ToTable("subscriptions");


        builder.Property(s => s.PlanId)
        .IsRequired();

        builder.Property(s => s.UserId)
        .IsRequired();

        builder.Property(s => s.Status)
        .IsRequired();

        builder.Property(s => s.BillingCycle)
        .IsRequired();

        builder.Property(s => s.StartDate)
        .IsRequired();

        builder.HasIndex(s => s.PlanId).IsUnique();
        builder.HasIndex(s => s.UserId).IsUnique();
    }
}