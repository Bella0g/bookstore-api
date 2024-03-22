using ProductModel;
using UserModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using book_store.Models;
using System.Text.Json.Serialization;

namespace CartModel
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public double TotalPrice { get; set; }

        public User User { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}



