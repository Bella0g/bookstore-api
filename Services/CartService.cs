using book_store.Data;
using CartModel;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using book_store.Models;



namespace book_store.Services
{
    public class CartService
    {
        private ApplicationDbContext _context;

        public CartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddProductToCart(int productId, string userId, int quantity = 1)
        {
            var product = await _context.Product.FindAsync(productId);
            var user = await _context.Users.FindAsync(userId);

            if (product != null && user != null)
            {
                var userCart = _context.Cart
                    .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.Product)
                    .FirstOrDefault(c => c.UserId == userId);

                if (userCart == null)
                {
                    userCart = new Cart
                    {
                        User = user,
                        CartItems = new List<CartItem>()
                    };
                    _context.Cart.Add(userCart);
                }

                var existingCartItem = userCart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

                if (existingCartItem != null)
                {
                    existingCartItem.Quantity += quantity;
                }
                else
                {
                    var cartItem = new CartItem
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        TotalPrice = product.Price * quantity,
                        Image = product.Image,
                        Title = product.Title
                    };
                    userCart.CartItems.Add(cartItem);
                }

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        //public async Task<bool> RemoveProductFromCart(int productid, string userid, int quantity = 1)
        //{
        //    var cartitem = _context.Cart
        //        .FirstOrDefault(c => c.ProductId == productid && c.UserId == userid);

        //    if (cartitem != null)
        //    {
        //        if (cartitem.Quantity > quantity)
        //        {
        //            cartitem.Quantity -= quantity;
        //            cartitem.TotalPrice -= quantity * cartitem.Product?.Price ?? 0;
        //        }
        //        else
        //        {
        //            _context.Cart.Remove(cartitem);

        //        }
        //        await _context.SaveChangesAsync();
        //        return true;
        //    }
        //    return false;
        //}
    }
}

