using TesteRiscoBR.Entidates;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteRiscoBR.Repository.Interface
{
    public interface ICategoryRepository
    {
        public void LoadCategories();

        public void AddCategory(CategoryEntity categoryEntity);

        public void RemoveCategory(int categoryId);

        public List<CategoryEntity> GetCategories();
    }
}
