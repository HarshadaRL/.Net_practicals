using System.Collections.Generic;
using System.Linq;
using ShopEaseConsoleApp.Models;

namespace ShopEaseConsoleApp.Repository
{
    public class CategoryRepository
    {
        private readonly List<Category> categories;

        public CategoryRepository()
        {
            categories = new List<Category>
            {
                new Category(1, "Electronics", "Electronic Items"),
                new Category(2, "Books", "Books and Magazines"),
                new Category(3, "Fashion", "Clothing and Accessories"),
                new Category(4, "Sports", "Sports Equipment"),
                new Category(5, "Furniture", "Home Furniture"),
                new Category(6, "Groceries", "Daily Grocery Items")
            };
        }

        public void AddCategory(Category category)
        {
            categories.Add(category);
        }

        public List<Category> GetAllCategories()
        {
            return categories;
        }

        public Category GetCategoryById(int categoryId)
        {
            return categories.FirstOrDefault(c => c.CategoryId == categoryId);
        }

        public bool UpdateCategory(Category category)
        {
            Category existing = GetCategoryById(category.CategoryId);

            if (existing == null)
                return false;

            existing.CategoryName = category.CategoryName;
            existing.Description = category.Description;

            return true;
        }

        public bool DeleteCategory(int categoryId)
        {
            Category category = GetCategoryById(categoryId);

            if (category == null)
                return false;

            categories.Remove(category);
            return true;
        }
    }
}