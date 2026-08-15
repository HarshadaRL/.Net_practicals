using _06Aug_2026.Data;
using _06Aug_2026.Models;
using _06Aug_2026.Repository;

namespace _06Aug_2026.Services
{
    //implement logic for CRUD method of Product entity
    //service - business logic
    //dbcontext - add, savechanges, find, tolist, update, remove

    public class ProductService : IProductService
    {
        private readonly AppDbContext context;

        public ProductService(AppDbContext context)
        {
            this.context = context;
        }

        public void AddProduct(Product product)
        {
            context.products.Add(product); //implementation of adding new Product with help of add
            context.SaveChanges(); //saving new added product in table
        }

        public void DeleteProduct(int id)
        {
            var product = context.products.Find(id);

            if (product != null) //check product available
            {
                context.products.Remove(product); //implementation of remove existing product from table
                context.SaveChanges(); //saving changes after deleting product
            }
        }

        public Product? GetProductById(int id)
        {
            return context.products.Find(id); //implementation of getProduct By ID with help of find
        }

        public List<Product> GetProducts()
        {
            return context.products.ToList(); //implementation of getProduct with help of toList
        }

        public void UpdateProduct(Product product)
        {
            context.products.Update(product); //implementation of updating existing Product with help of update
            context.SaveChanges(); //saving existing updated product in table
        }
    }
}
