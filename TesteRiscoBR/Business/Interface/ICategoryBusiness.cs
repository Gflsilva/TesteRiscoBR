using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteRiscoBR.Repository.Interface
{
    public interface ICategoryBusiness
    {
        public void AddCategory();

        public void RemoveCategory();

        public void ListCategories();
    }
}
