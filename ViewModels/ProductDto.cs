﻿namespace book_store.ViewModels
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title {  get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
    }
}
