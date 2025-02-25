using TesteRiscoBR.Entidates;
using TesteRiscoBR.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteRiscoBR.Repository.Interface;

namespace TesteRiscoBR.Business
{
    public class TradeBusiness : ITradeBusiness
    {
        ITradeRepository _tradeRepository;

        public TradeBusiness(ITradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }

        public void AddTrade(TradeRepository repository)
        {
            Console.Write("Digite o valor da operação: ");
            double value = double.Parse(Console.ReadLine());

            Console.Write("Digite o setor do cliente (Public/Private): ");
            string sector = Console.ReadLine();

            Console.Write("Digite a data do próximo pagamento (MM/dd/yyyy): ");
            var date = Console.ReadLine();

            DateTime nextPaymentDate = DateTime.Parse(date);

            DateTime referenceDate = DateTime.Today;
            var trade = new TradeEntity { Value = value, ClientSector = sector, NextPaymentDate = nextPaymentDate };

            trade.Category = TradeClassifier.Classify(trade, referenceDate);

            repository.AddTrade(trade);
            Console.WriteLine("Trade cadastrada com sucesso!");
        }


        public void RemoveTrades(TradeRepository repository)
        {
            Console.Write("Digite o ID da categoria a ser removida: ");
            int categoryId = int.Parse(Console.ReadLine());
            _tradeRepository.RemoveTrades(categoryId);
            Console.WriteLine("Categoria removida com sucesso!");
        }

        public void ListTrades(TradeRepository repository)
        {
            var trades = repository.GetTrades();
            Console.WriteLine("\nLista de Trades Cadastradas:");
            foreach (var trade in trades)
            {
                Console.WriteLine($"ID: {trade.Id} | Valor: {trade.Value} | Setor: {trade.ClientSector} | Categoria: {trade.Category}");
            }
        }
    }
}
