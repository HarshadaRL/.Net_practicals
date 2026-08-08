using _28july.Models;

namespace _28july.Services
{
    public interface IProductService
    {
        List<Product> GetAll();

        Product? GetById(int id);

        Product AddProduct(Product product);

        Product? UpdateProduct(int id, Product product);

        bool DeleteProduct(int id);
    }
}