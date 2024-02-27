using book_store.Data;
using ProductModel;

namespace book_store.Services;

public class HomeService
{
}

public class ProductService
{
    private ApplicationDbContext _context;
    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }
    public Product CreateProduct(int productId, string image, string title, string author, string category, string description, double price)
    {
        Product product = new Product(productId, image, title, author, category, description, price);
        _context.Product.Add(product);
        _context.SaveChanges();
        return product;
    }

    public Product DeleteProduct(int productId)
    {
        Product product = _context.Product.Find(productId);
        if (product == null)
        {
            return null;
        }

        _context.Product.Remove(product);
        _context.SaveChanges();
        return product;
    }
    public List<Product> GetAllProducts()
    {
        return _context.Product.ToList();
    }
}

