using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    /// <summary>
    /// Configuration for the Sale Order entity.
    /// </summary>
    public class SaleOrderConfiguration : IEntityTypeConfiguration<SaleOrder>
    {
        public void Configure(EntityTypeBuilder<SaleOrder> builder)
        {
            builder.ToTable("SaleOrder");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.SalerOrderNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.Customer)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Branch)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.TotalValue)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(s => s.Canceled)
                .HasDefaultValue(false);

            builder.HasMany(s => s.Products)
                .WithOne()
                .HasForeignKey(i => i.SaleOrderId);
        }
    }
}
