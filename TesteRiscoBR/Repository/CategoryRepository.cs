using TesteRiscoBR.Entidates;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteRiscoBR.Repository.Interface;

namespace TesteRiscoBR.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private const string CategoriesFilePath = "categories.json";
        private List<CategoryEntity> categories;

        public CategoryRepository()
        {
            LoadCategories();
        }

        public void LoadCategories()
        {
            if (File.Exists(CategoriesFilePath))
            {
                string json = File.ReadAllText(CategoriesFilePath);
                categories = JsonConvert.DeserializeObject<List<CategoryEntity>>(json) ?? new List<CategoryEntity>();
            }
            else
            {
                categories = new List<CategoryEntity>();
            }
        }

        private void SaveCategories()
        {
            string json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            File.WriteAllText(CategoriesFilePath, json);
        }

        public void AddCategory(string categoryName)
        {
            var category = new CategoryEntity { Id = categories.Count > 0 ? categories[^1].Id + 1 : 1, Name = categoryName };
            categories.Add(category);
            SaveCategories();
        }

        public void RemoveCategory(int categoryId)
        {
            categories.RemoveAll(c => c.Id == categoryId);
            SaveCategories();
        }

        public List<CategoryEntity> GetCategories()
        {
            return categories;
        }
    }
}
