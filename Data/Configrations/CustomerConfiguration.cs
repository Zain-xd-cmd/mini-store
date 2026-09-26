using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customer");
        
        builder.HasKey(c=>c.Id);
        
        builder.Property(c=>c.Name)
        .HasColumnName("name")
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(c=>c.Email)
        .HasColumnName("email")
        .HasMaxLength(255)
        .IsRequired();

       


    }
}