using System.Collections.Generic;
using ShopEaseConsoleApp.Models;
using ShopEaseConsoleApp.Repository;

namespace ShopEaseConsoleApp.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository categoryRepository;

        public CategoryService(CategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public void AddCategory(Category category)
        {
            categoryRepository.AddCategory(category);
        }

        public List<Category> GetAllCategories()
        {
            return categoryRepository.GetAllCategories();
        }

        public Category GetCategoryById(int categoryId)
        {
            return categoryRepository.GetCategoryById(categoryId);
        }

        public bool UpdateCategory(Category category)
        {
            return categoryRepository.UpdateCategory(category);
        }

        public bool DeleteCategory(int categoryId)
        {
            return categoryRepository.DeleteCategory(categoryId);
        }
    }
}