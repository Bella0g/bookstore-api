using UserModel;

namespace CartModel;

public class Cart
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public User User { get; set; }

    public Cart() { }
    public Cart(int id, int quantity, double price, User user)
    {
        Id = id;
        Quantity = quantity;
        Price = price;
        User = user;
    }
}