namespace CartModel;

public class Cart
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public Cart(int id, int quantity, double price)
    {
        Id = id;
        Quantity = quantity;
        Price = price;
    }
}