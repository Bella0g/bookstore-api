using book_store.Dto;

namespace book_store.Interface
{
    public interface CartInterface
    {
        Task<bool> AddProductToCart(int productId, string userId, int quantity = 1);
        Task<bool> RemoveProductFromCart(int productId, string userId, int quantity = 1);
        List<CartDto> GetCart(string userId);
    }
}
