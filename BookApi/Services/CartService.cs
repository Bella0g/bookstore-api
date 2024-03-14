using book_store.Dto;
using book_store.Repository;





namespace book_store.Services
{
    public class CartService
    {
        private CartRepository _cartRepository;

        public CartService(CartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<bool> AddProductToCart(int productId, string userId, int quantity = 1)
        {
            return await _cartRepository.AddProductToCart(productId, userId, quantity);
        }

        public async Task<bool> RemoveProductFromCart(int productId, string userId, int quantity = 1)
        {
            return await _cartRepository.RemoveProductFromCart(productId, userId, quantity);
        }

        public List<CartDto> GetCart(string userId)
        {
            return _cartRepository.GetCart(userId);
        }
    }
}



