using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteRiscoBR.Repository.Interface
{
    public interface ICategoryBusiness
    {
        public void AddCategory(TradeRepository repository);

        public void RemoveCategory(TradeRepository repository);

        public void ListCategories(TradeRepository repository);
    }
}
