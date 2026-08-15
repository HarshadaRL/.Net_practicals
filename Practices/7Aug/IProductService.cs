using _7_Aug.Models;

namespace _7_Aug.Repository
{
    public interface IProductService
    {
        // Defines what operations are available

        List<Product> GetProducts();

        Product? GetProductById(int id);

        Product AddProduct(Product product);
    }
}
