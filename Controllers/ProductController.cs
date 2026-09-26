using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/products")]
public class ProductController(AppDbContext context) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> Get([FromQuery]int price = 0,[FromQuery] string orderBy = "ASC")
    {

        var products = context.Products.Where(p=>p.Price > price)
        .Select(p=>new
        {
            p.Id,
            p.Name,
            p.Price
        });
        if(orderBy == "ASC")
        {
           products = products.OrderBy(p=>p.Price);
        }
        else
        {
           products =  products.OrderByDescending(p=>p.Price);
        }
        
        var productsAsync = await products.ToListAsync();
        return Ok(productsAsync);
    }
     [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute]int id)
    {
        var product = await context.Products.FindAsync(id);
        if(product is null)
        {
            return NotFound();
        }

       
        return Ok(product);
    }
     [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery]string name = "")
    {
        var products = await context.Products.Where(p=>p.Name.Contains(name)).ToListAsync();
        
       
        return Ok(products);
    }

    [HttpGet("exists/{name}")]
    public async Task<IActionResult> Exists(string name)
    {
        var product = await context.Products.AnyAsync(p=>p.Name==name);
        
       
        return Ok(product);
    }
}