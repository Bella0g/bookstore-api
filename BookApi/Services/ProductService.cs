using book_store.Repository;
using book_store.ViewModels;
using ProductModel;

namespace book_store.Services;

public class ProductService
{
    private ProductRepository _productRepository;

    public ProductService(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Product CreateProduct(ProductDto dto)
    {
        return _productRepository.CreateProduct(dto);
    }

    public Product DeleteProduct(int Id)
    {
        return _productRepository.DeleteProduct(Id);
    }

    public Product UpdateProduct(ProductDto dto)
    {
        return _productRepository.UpdateProduct(dto);
    }

    public List<Product> GetAllProducts()
    {
     return _productRepository.GetAllProducts();
    }
}