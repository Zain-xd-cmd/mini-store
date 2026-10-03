using Microsoft.EntityFrameworkCore;
public class CategoryRepository(AppDbContext context) : ICategoryRepository
{
    public async Task AddCategoryAsync(Category category)
    {
       await context.Categories.AddAsync(category);
       await context.SaveChangesAsync();
    }

    public async Task DeleteCategoryAsync(Category category)
    {
        context.Categories.Remove(category);
        await context.SaveChangesAsync();
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await context.Categories.ToListAsync();
    }

    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        return await context.Categories.FindAsync(id);
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        context.Categories.Update(category);
        await context.SaveChangesAsync();
    }
}