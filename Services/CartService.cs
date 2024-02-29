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
        public async Task<bool> AddProductToCart(int productId, string userId)
        {
            var product = await _context.Product.FindAsync(productId);
            var user = await _context.Users.FindAsync(userId);

            if (product != null && user != null)
            {
                var cartItem = new Cart
                {
                    Product = product,
                    User = user,
                    Image = product.Image,
                    Title = product.Title,
                    Quantity = 1,
                    TotalPrice = product.Price
                };

                _context.Cart.Add(cartItem);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
