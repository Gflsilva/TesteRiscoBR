using TesteRiscoBR.Repository;
using TesteRiscoBR.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteRiscoBR.Entidates;
using TesteRiscoBR.Enum;
using Newtonsoft.Json.Linq;
using System.Threading;
using TesteRiscoBR.Model.Category.Create;
using FluentValidation;

namespace TesteRiscoBR.Business
{
    public class CategoryBusiness : ICategoryBusiness
    {
        ICategoryRepository _categoryRepository;
        CategoryEntity categoryEntity;

        public CategoryBusiness(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void AddCategory()
        {
            categoryEntity = new CategoryEntity();

            categoryEntity = PreencherCampos(categoryEntity);


            if (categoryEntity.Erros)
            {
                _categoryRepository.AddCategory(categoryEntity);

                Console.WriteLine("Categoria adicionada com sucesso!");
            }
            else
            {
                Console.WriteLine("\nVerifique as informações preenchidas!\n");
            }
        }

        public void RemoveCategory()
        {
            Console.Write("Digite o ID da categoria a ser removida: ");
            int categoryId = int.Parse(Console.ReadLine());

            _categoryRepository.RemoveCategory(categoryId);
            Console.WriteLine("Categoria removida com sucesso!");
        }

        public void ListCategories()
        {
            var categories = _categoryRepository.GetCategories();
            Console.WriteLine("\nLista de Categorias:");

            foreach (var category in categories)
            {
                Console.WriteLine($"ID: {category.Id} | Nome: {category.Name} | Tipo: {category.Type} | Operador: {category.Operator} | Valor: {category.Value}");
            }
        }

        private CategoryEntity PreencherCampos(CategoryEntity categoryEntity)
        {
            try
            {
                Console.Write("Digite o nome da nova categoria: ");
                categoryEntity.Name = Console.ReadLine();

                Console.Write("Digite o tipo da nova categoria (PUBLIC/PRIVATE): ");
                categoryEntity.Type = Console.ReadLine();

                Console.Write("Digite o operador da nova categoria (=/>/<): ");
                categoryEntity.Operator = Console.ReadLine();

                Console.Write("Digite o valor da nova categoria: ");
                categoryEntity.Value = decimal.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nVerifique as informações preenchidas. " + ex.Message + "\n");

                return categoryEntity;
            }

            categoryEntity.Erros = Validate(categoryEntity);

            return categoryEntity;
        }

        private bool Validate(CategoryEntity categoryEntity)
        {
            var validator = new CreateRequestValidator();
            var validationResult = validator.Validate(categoryEntity);

            if (!validationResult.IsValid)
                foreach (var error in validationResult.Errors)
                    Console.WriteLine("\n" + error.ErrorMessage);

            return validationResult.IsValid;
        }
    }
}
