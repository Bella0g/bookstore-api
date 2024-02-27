using System.ComponentModel.DataAnnotations.Schema;


namespace ProductModel
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Product(int productId, string image, string title, string author, string category, string description, double price)
        {
            ProductId = productId;
            Image = image;
            Title = title;
            Author = author;
            Category = category;
            Description = description;
            Price = price;
        }
    }
}
