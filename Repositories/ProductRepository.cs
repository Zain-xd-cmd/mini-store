using Microsoft.EntityFrameworkCore;
public class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task AddProductAsync(Product product)
    {
       await context.Products.AddAsync(product);
       await context.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(Product product)
    {
        context.Products.Remove(product);
        await context.SaveChangesAsync();
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await context.Products.ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await context.Products.FindAsync(id);
    }

    public async Task UpdateProductAsync(Product product)
    {
        context.Products.Update(product);
        await context.SaveChangesAsync();
    }
}