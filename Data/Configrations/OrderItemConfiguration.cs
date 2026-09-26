using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItem");
        
        builder.HasKey(o=>o.Id);
        
        builder.Property(o=>o.Quantity)
        .HasColumnName("quantity")
        .IsRequired();

        builder.Property(o=>o.UnitPrice)
        .HasColumnName("unit_price")
        .HasPrecision(10,2)
        .IsRequired();

    

        builder.HasOne(o=>o.Order)
        .WithMany(o=>o.OrderItems)
        .HasForeignKey(o=>o.OrderId)
        .IsRequired();

         builder.HasOne(o=>o.Product)
        .WithMany(p=>p.OrderItems)
        .HasForeignKey(o=>o.ProductId)
        .IsRequired();


    }
}