using book_store.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace book_store.Controllers
{
    [ApiController]
    [Route("carts")]
    public class CartController : ControllerBase
    {
        private CartService _cartService ;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("addProduct")]
        [Authorize("addProduct")]
        public async Task<IActionResult> AddProductToCart([FromBody] AddProductToCartRequest request)
        {
            var success = await _cartService.AddProductToCart(request.ProductId, request.UserId);

            if (success)
            {
                return Ok("Product added to cart successfully.");
            }

            return BadRequest("Unable to add product to cart.");
        }

        //[HttpDelete("removeProduct")]
        //[Authorize("removeProduct")]
        //public async Task<IActionResult> RemoveProductFromCart([FromBody] RemoveProductToCartRequest request)
        //{
        //    var success = await _cartService.RemoveProductFromCart(request.ProductId, request.UserId, request.Quantity);

        //    if (success)
        //    {
        //        return Ok("Product removed from cart successfully.");
        //    }

        //    return BadRequest("Unable to remove product from cart.");
        //}
    }
}
public class AddProductToCartRequest
{
    public int ProductId { get; set; }
    public string UserId { get; set; }
}

public class RemoveProductToCartRequest
{
    public int ProductId { get; set; }
    public string UserId { get; set; }
    public int Quantity { get; set; }
}