using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using book_store.Models;
using book_store.Services;
using ProductModel;


namespace book_store.Controllers;


[ApiController]
[Route("api")]
public class ProductController : Controller
{
    private ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;

    }

    [HttpPost("product")]
    public IActionResult CreateProduct([FromBody] Product dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            Product product = _productService.CreateProduct(dto.Id, dto.Image, dto.Title, dto.Author, dto.Category, dto.Description, dto.Price);
            return Ok(product);
        }
        catch (ArgumentException)
        {
            return BadRequest();
        }
    }

    [HttpDelete("product/{Id}")]
    public IActionResult DeleteProduct(int Id)
    {
        Product deletedProduct = _productService.DeleteProduct(Id);
        if (deletedProduct == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPut("product/{Id}")]
    public IActionResult UpdateProduct(int Id, [FromBody] Product updatedProduct)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            Product product = _productService.UpdateProduct(Id, updatedProduct);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpGet("products")]
    public List<Product> GetProducts()
    {
        return _productService.GetAllProducts();
    }
}
