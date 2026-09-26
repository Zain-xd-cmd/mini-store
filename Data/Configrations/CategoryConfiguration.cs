using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");

        builder.HasKey(c=>c.Id);

        builder.Property(c=>c.Name)
        .HasColumnName("name")
        .HasMaxLength(255)
        .IsRequired();


    }
}