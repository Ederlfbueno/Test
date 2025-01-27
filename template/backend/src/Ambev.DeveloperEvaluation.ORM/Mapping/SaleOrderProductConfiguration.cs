using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    /// <summary>
    /// Configuration for the SaleOrderProduct entity.
    /// </summary>
    public class SaleOrderProductConfiguration : IEntityTypeConfiguration<SaleOrderProduct>
    {
        public void Configure(EntityTypeBuilder<SaleOrderProduct> builder)
        {
            builder.ToTable("SaleOrderProducts");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(i => i.Quantity)
                .IsRequired();

            builder.Property(i => i.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(i => i.Discount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(i => i.TotalValue)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
        }
    }
}
