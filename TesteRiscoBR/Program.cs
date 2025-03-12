using System;
using System.Collections.Generic;
using System.IO;
using TesteRiscoBR;
using TesteRiscoBR.Entidates;
using TesteRiscoBR.Repository;
using Newtonsoft.Json;
using TesteRiscoBR.Repository.Interface;
using TesteRiscoBR.Business;
using TesteRiscoBR.Business.Interface;

// Modelo da entidade Categoria


// Modelo da entidade Trade


// Classe para gerenciar o armazenamento em JSON


// 1 - Preciso que a aplicação, ao ser executada, valide todas as trades cadastradas e classifique-as de acordo com a categoria.
// 2 - Imaginando um cenário onde as trades tem diversas regras de classificação, como você faria para implementar essas regras de forma que seja fácil adicionar novas regras sem alterar o código já existente?

// Programa principal
class Program
{
    static void Main()
    {
        ICategoryRepository _categoryRepository = new CategoryRepository();
        ITradeRepository _tradeRepository = new TradeRepository();

        IEnumerable<ITradeClassificationRule> tradeRules = new List<ITradeClassificationRule> {
            new ExpiredTradeRule(), new HighRiskTradeRule(), new MediumRiskTradeRule(), new DBConsultRisk(_categoryRepository) 
        };

        IClassifierTrade _classifierTrade = new ClassifierTrade(tradeRules);

        ICategoryBusiness _categoryBusiness = new CategoryBusiness(_categoryRepository);
        ITradeBusiness _tradeBusiness = new TradeBusiness(_tradeRepository, _classifierTrade);

        while (true)
        {
            Console.WriteLine("\n1. Cadastrar Trade");
            Console.WriteLine("2. Remover Trades");
            Console.WriteLine("3. Listar Trades");
            Console.WriteLine("\n4. Cadastrar Categoria");
            Console.WriteLine("5. Remover Categoria");
            Console.WriteLine("6. Listar Categorias");
            Console.WriteLine("\n7. Realizar validação em lote.");
            Console.WriteLine("\n8. Sair");
            Console.Write("\n Escolha uma opção: ");
            var option = Console.ReadLine();

            try
            {
                switch (option)
                {
                    case "1":
                        _tradeBusiness.AddTrade();
                        break;
                    case "2":
                        _tradeBusiness.RemoveTrades();
                        break;
                    case "3":
                        _tradeBusiness.ListTrades();
                        break;


                    case "4":
                        _categoryBusiness.AddCategory();
                        break;
                    case "5":
                        _categoryBusiness.RemoveCategory();
                        break;
                    case "6":
                        _categoryBusiness.ListCategories();
                        break;

                    case "7":
                        _tradeBusiness.TradeClassifier();
                        break;

                    case "8":
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nVerifique as informações preenchidas. " + ex.Message + "\n");
            }
        }
    }
}
