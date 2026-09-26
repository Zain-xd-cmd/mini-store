public class ProductResponse
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public string? Description { get; set; }

    public int CategoryId { get; set; }

    public static ProductResponse FromModel(Product product)
    {
        return new ProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            Description = product.Description,
            CategoryId = product.CategoryId
        };
    }
     public static List<ProductResponse> FromListModel(List<Product> products)
    {
        return products.Select(p=>ProductResponse.FromModel(p)).ToList();
       
    }
}