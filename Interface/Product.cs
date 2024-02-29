using ProductModel;

namespace book_store.Interface
{
    public interface ProductInterface
    {
        Product GetAllProducts(int id, string name);
    }
}
