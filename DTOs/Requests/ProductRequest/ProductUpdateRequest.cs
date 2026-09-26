public class ProductUpdateRequest
{
     public string Name { get; set; }=null!;

     public decimal Price { get; set; }

     public string Description {get;set;}=null!;

     public Product ToModel(Product product)
    {
        product.Name=this.Name;
        product.Price=this.Price;
        product.Description=this.Description;

        return product;
    }

}