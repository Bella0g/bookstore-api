using book_store.ViewModels;
using ProductModel;

namespace book_store.Interface
{
    public interface ProductInterface
    {
        Product CreateProduct(ProductDto dto);
        Product DeleteProduct(int Id);
        Product UpdateProduct(ProductDto dto);
        List<Product> GetAllProducts();
    }
}
