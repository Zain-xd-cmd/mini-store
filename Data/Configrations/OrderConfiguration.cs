using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Order");
        
        builder.HasKey(o=>o.Id);
        
        builder.Property(o=>o.OrderDate)
        .HasColumnName("order_date")
        .IsRequired();

         builder.HasOne(o=>o.Customer)
        .WithMany(c=>c.Orders)
        .HasForeignKey(o=>o.CustomerId)
        .IsRequired();

       


    }
}