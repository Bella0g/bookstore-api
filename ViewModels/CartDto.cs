
namespace book_store.Dto
{
    public class CartDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public double TotalPrice { get; set; }
        public List<CartItemDto> CartItems { get; set; } = new List<CartItemDto>();
    }
    public class CartItemDto
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public int ProductId { get; set; }   
    }
    public class AddProductToCartRequestDto
    {
        public int ProductId { get; set; }
        public string UserId { get; set; }
    }
    public class RemoveProductFromCartRequestDto
    {
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public int Quantity { get; set; }
    }
}
