using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using book_store.Models;
using book_store.Services;
using ProductModel;
using static System.Net.Mime.MediaTypeNames;
using System.IO.Pipelines;

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

//public class homecontroller : controller
//{
//    private readonly ilogger<homecontroller> _logger;

//    public homecontroller(ilogger<homecontroller> logger)
//    {
//        _logger = logger;
//    }

//    public iactionresult index()
//    {
//        return view();
//    }

//    public iactionresult privacy()
//    {
//        return view();
//    }

//    //[responsecache(duration = 0, location = responsecachelocation.none, nostore = true)]
//    //public iactionresult error()
//    //{
//    //    return view(new errorviewmodel { requestid = activity.current?.id ?? httpcontext.traceidentifier });
//    //}

//}