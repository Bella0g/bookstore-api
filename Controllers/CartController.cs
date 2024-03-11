using book_store.Dto;
using book_store.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace book_store.Controllers
{
    [ApiController]
    [Route("carts")]
    public class CartController : ControllerBase
    {
        private CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("addProduct")]
        [Authorize("addProduct")]
        public async Task<IActionResult> AddProductToCart([FromBody] AddProductToCartRequestDto request)
        {
            var success = await _cartService.AddProductToCart(request.ProductId, request.UserId);

            if (success)
            {
                return Ok("Product added to cart successfully.");
            }

            return BadRequest("Unable to add product to cart.");
        }

        [HttpDelete("removeProduct")]
        [Authorize("removeProduct")]
        public async Task<IActionResult> RemoveProductFromCart([FromBody] RemoveProductFromCartRequestDto request)
        {
            var success = await _cartService.RemoveProductFromCart(request.ProductId, request.UserId, request.Quantity);

            if (success)
            {
                return Ok($"Removed {request.Quantity} product id: {request.ProductId} from the cart successfully.");
            }

            return BadRequest("Unable to remove product from cart.");
        }

        [HttpGet("UserCart")]
        [Authorize("UserCart")]
        public IActionResult GetUserCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userCart = _cartService.GetCart(userId);

            return Ok(userCart);
        }
    }
}

