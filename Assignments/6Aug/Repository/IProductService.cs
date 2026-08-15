using _06Aug_2026.Models;

namespace _06Aug_2026.Repository
{
    //define all CRUD(create,read,update,delete) method for performing on Product entity
    public interface IProductService
    {
        List<Product> GetProducts(); //fetch all products from product table

        Product? GetProductById(int id); //fetch product detail from products table based on PId

        void AddProduct(Product product); //add new product record in products table

        void UpdateProduct(Product product); //modify product details from products table based on PId

        void DeleteProduct(int id); //remove product record from products table based on PId
    }
}
