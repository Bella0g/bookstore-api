using ProductModel;
using UserModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CartModel
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        // Navigation property
        public User User { get; set; }
        public Product Product { get; set; }
       
        public Cart() { }

        // Create Cart object
        public Cart(string image, string title, double totalPrice, int quantity, User user, Product product)
        {
            Image = image;
            Title = title;
            TotalPrice = totalPrice;
            Quantity = quantity;
            User = user;
            Product = product;
        }
    }
}

