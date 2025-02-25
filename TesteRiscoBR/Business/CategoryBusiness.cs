using TesteRiscoBR.Repository;
using TesteRiscoBR.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteRiscoBR.Business
{
    public class CategoryBusiness : ICategoryBusiness
    {
        ICategoryRepository _categoryRepository;

        public CategoryBusiness(ICategoryRepository categoryRepository) {
            _categoryRepository = categoryRepository;
        }

        public void AddCategory(TradeRepository repository)
        {
            Console.Write("Digite o nome da nova categoria: ");
            string categoryName = Console.ReadLine();
            _categoryRepository.AddCategory(categoryName);
            Console.WriteLine("Categoria adicionada com sucesso!");
        }

        public void RemoveCategory(TradeRepository repository)
        {
            Console.Write("Digite o ID da categoria a ser removida: ");
            int categoryId = int.Parse(Console.ReadLine());
            _categoryRepository.RemoveCategory(categoryId);
            Console.WriteLine("Categoria removida com sucesso!");
        }

        public void ListCategories(TradeRepository repository)
        {
            var categories = _categoryRepository.GetCategories();
            Console.WriteLine("\nLista de Categorias:");
            foreach (var category in categories)
            {
                Console.WriteLine($"ID: {category.Id} | Nome: {category.Name}");
            }
        }
    }
}
