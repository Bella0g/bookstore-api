using book_store.Data;
using Microsoft.EntityFrameworkCore;
using CartModel;
using book_store.Dto;
using book_store.Models;
using book_store.Interface;

namespace book_store.Repository
{
    public class CartRepository : CartInterface
    {
        private ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddProductToCart(int productId, string userId, int quantity = 1)
        {
            var product = await _context.Product.FindAsync(productId);
            var user = await _context.Users.FindAsync(userId);

            if (product != null && user != null)
            {
                var userCart = await _context.Cart
                    .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.Product)
                    .FirstOrDefaultAsync(c => c.UserId == userId);

                if (userCart == null)
                {
                    userCart = new Cart
                    {
                        User = user,
                        CartItems = new List<CartItem>(),
                        TotalPrice = 0
                    };
                    _context.Cart.Add(userCart);
                }

                var existingCartItem = userCart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

                if (existingCartItem != null)
                {
                    existingCartItem.Quantity += quantity;
                    existingCartItem.Price = existingCartItem.Product.Price * existingCartItem.Quantity;
                }
                else
                {
                    var cartItem = new CartItem
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        Price = product.Price * quantity,
                        Image = product.Image,
                        Title = product.Title
                    };
                    userCart.CartItems.Add(cartItem);
                }
                userCart.TotalPrice = userCart.CartItems.Sum(ci => ci.Price * ci.Quantity);

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> RemoveProductFromCart(int productId, string userId, int quantity = 1)
        {
            var userCart = await _context.Cart
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (userCart != null)
            {
                var existingCartItem = userCart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

                if (existingCartItem != null)
                {
                    if (existingCartItem.Quantity > quantity)
                    {
                        existingCartItem.Quantity -= quantity;
                        existingCartItem.Price -= quantity * existingCartItem.Product?.Price ?? 0;
                        userCart.TotalPrice -= quantity * existingCartItem.Product?.Price ?? 0;
                    }
                    else
                    {
                        userCart.TotalPrice -= existingCartItem.Price;
                        userCart.CartItems.Remove(existingCartItem);
                    }

                    await _context.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }

        public List<CartDto> GetCart(string userId)
        {
            var userCart = _context.Cart
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefault(c => c.UserId == userId);

            if (userCart != null)
            {
                var cartDto = new CartDto
                {
                    Id = userCart.Id,
                    UserId = userCart.UserId,
                    CartItems = userCart.CartItems.Select(cartItem => new CartItemDto
                    {
                        Title = cartItem.Product.Title,
                        Image = cartItem.Product.Image,
                        Price = cartItem.Price,
                        Quantity = cartItem.Quantity,
                        ProductId = cartItem.ProductId
                    }).ToList(),
                    TotalPrice = userCart.TotalPrice
                };

                return new List<CartDto> { cartDto };
            }
            return new List<CartDto>();
        }
    }
}
