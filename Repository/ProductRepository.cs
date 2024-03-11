using book_store.Data;
using book_store.Interface;
using book_store.ViewModels;
using ProductModel;

namespace book_store.Repository
{
    public class ProductRepository : ProductInterface
    {
        private ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Product CreateProduct(ProductDto dto)
        {
            Product product = new Product(dto.Id, dto.Image, dto.Title, dto.Author, dto.Category, dto.Description, dto.Price);
            _context.Product.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product DeleteProduct(int Id)
        {
            Product product = _context.Product.Find(Id);
            if (product == null)
            {
                return null;
            }
            _context.Product.Remove(product);
            _context.SaveChanges();
            return product;
        }

        public Product UpdateProduct(ProductDto dto)
        {
            Product product = _context.Product.Find(dto.Id);

            if (product == null)
            {
                return null;
            }
            product.Image = dto.Image;
            product.Title = dto.Title;
            product.Author = dto.Author;
            product.Category = dto.Category;
            product.Description = dto.Description;
            product.Price = dto.Price;

            _context.SaveChanges();
            return product;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Product.ToList();
        }
    }


}
