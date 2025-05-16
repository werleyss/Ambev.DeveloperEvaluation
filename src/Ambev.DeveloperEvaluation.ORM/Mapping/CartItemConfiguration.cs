using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable("CartItems");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(p => p.CartId).IsRequired();
        builder.Property(p => p.ProductId).IsRequired();
        builder.Property(p => p.ProductTitle).IsRequired();
        builder.Property(p => p.Quantity).IsRequired();
        builder.Property(p => p.Discount);
        builder.Property(p => p.UnitPrice).IsRequired();
        builder.Property(p => p.TotalPrice).IsRequired();

    }
}
