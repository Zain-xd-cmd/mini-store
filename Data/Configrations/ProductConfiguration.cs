using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");
        
        builder.HasKey(p=>p.Id);
        
        builder.Property(p=>p.Name)
        .HasColumnName("name")
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(p=>p.Price)
        .HasColumnName("price")
        .HasPrecision(10,2)
        .IsRequired();
         builder.Property(p=>p.Description)
        .HasColumnName("description")
        .HasMaxLength(255)
        .IsRequired(false);
        

        builder.Property(p=>p.Stock)
        .HasColumnName("stock")
        .IsRequired();

        builder.HasOne(p=>p.Category)
        .WithMany(c=>c.Products)
        .HasForeignKey(p=>p.CategoryId)
        .IsRequired();


    }
}