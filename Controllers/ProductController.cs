using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/products")]
public class ProductController(IProductRepository productRepository) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        var products = await productRepository.GetAllProductsAsync();

        return Ok(ProductResponse.FromListModel(products));

       
    }

     [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute]int id)
    {
        var product = await productRepository.GetProductByIdAsync(id);
        if(product is null)
        {
            return NotFound();
        }

       
        return Ok(ProductResponse.FromModel(product));
    }
     
     [HttpPost("")]
    public async Task<IActionResult> Post([FromBody]ProductCreateRequest productBody)
    {
        var product = productBody.ToModel();
        await productRepository.AddProductAsync(product);
        
        return CreatedAtAction(
          nameof(Get),
          new { id = product.Id },
          ProductResponse.FromModel(product)
);
    }
     

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductUpdateRequest productBody)
    {
       var product = await productRepository.GetProductByIdAsync(id);
       if(product is null)
        {
            return NotFound();
        }
       
         product = productBody.ToModel(product);
         await productRepository.UpdateProductAsync(product);
       
        return Ok(ProductResponse.FromModel(product));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
       var product = await productRepository.GetProductByIdAsync(id);
       if(product is null)
        {
            return NotFound();
        }
       
         await productRepository.DeleteProductAsync(product);
       
        return NoContent();
    }
}