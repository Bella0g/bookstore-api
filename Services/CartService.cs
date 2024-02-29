using book_store.Data;
using CartModel;

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
                // Checking if the product exists in cart for the current user.
                var existingCartItem = _context.Cart
                    .FirstOrDefault(c => c.ProductId == productId && c.UserId == userId);

                if (existingCartItem != null)
                {
                    // if product exists, the quantity increase with 1.
                    existingCartItem.Quantity += quantity;
                }
                else
                {
                    // If the product does'nt exist, adds a new product to the cart.
                    var cartItem = new Cart
                    {
                        Product = product,
                        User = user,
                        Image = product.Image,
                        Title = product.Title,
                        Quantity = quantity,
                        TotalPrice = product.Price * quantity
                    };

                    _context.Cart.Add(cartItem);
                }

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

    }
}
