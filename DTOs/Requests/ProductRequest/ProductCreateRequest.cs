public class ProductCreateRequest
{
    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public string? Description {get;set;}

    public int CategoryId { get; set; }

     public Product ToModel()
    {
       

        return new Product
        {
           Name = this.Name,
           Price = this.Price,
           Stock = this.Stock,
           Description = this.Description,
           CategoryId = this.CategoryId

        };
    }

}