using ProductModel;
using UserModel;
using System.Collections.Generic;

namespace CartModel
{
    public class Cart
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
       
        public Cart() { }
        public Cart(int id, string image, string title, User user)
        {
            Id = id;
            Image = image;
            Title = title;
            User = user;
        }
    }
}

//public class CartItem
//{
//    public int Id { get; set; }
//    public Product Product { get; set; }
//    public int Quantity { get; set; }
//    public double Subtotal => Quantity * Product.Price; // Delsumma för kundvagnsobjektet
//}