using TesteRiscoBR.Entidates;
using TesteRiscoBR.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteRiscoBR.Repository.Interface;
using TesteRiscoBR.Model.Trade.Create;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TesteRiscoBR.Business
{
    public class TradeBusiness : ITradeBusiness
    {
        ITradeRepository _tradeRepository;
        TradeEntity tradeEntity;

        public TradeBusiness(ITradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }

        public void AddTrade()
        {
            tradeEntity = new TradeEntity();

            tradeEntity = PreencherCampos(tradeEntity);

            _tradeRepository.AddTrade(tradeEntity);
            Console.WriteLine("Trade cadastrada com sucesso!");
        }

        public void RemoveTrades()
        {
            Console.Write("Digite o ID da categoria a ser removida: ");
            int categoryId = int.Parse(Console.ReadLine());

            _tradeRepository.RemoveTrades(categoryId);
            Console.WriteLine("Categoria removida com sucesso!");
        }

        public void ListTrades()
        {
            var trades = _tradeRepository.GetTrades();

            Console.WriteLine("\nLista de Trades Cadastradas:");

            foreach (var trade in trades)
            {
                Console.WriteLine($"ID: {trade.Id} | Valor: {trade.Value} | Setor: {trade.ClientSector} | Categoria: {trade.Category}");
            }
        }

        private TradeEntity PreencherCampos(TradeEntity tradeEntity)
        {
            try
            {
                Console.Write("Digite o valor da operação: ");
                tradeEntity.Value = float.Parse(Console.ReadLine());

                Console.Write("Digite o setor do cliente (Public/Private): ");
                tradeEntity.ClientSector = Console.ReadLine();

                Console.Write("Digite a data do próximo pagamento (MM/dd/yyyy): ");
                tradeEntity.NextPaymentDate = DateTime.Parse(Console.ReadLine());

                TradeClassifier tradeClassifier = new TradeClassifier();
                tradeEntity.Category = tradeClassifier.Classify(tradeEntity);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nVerifique as informações preenchidas. " + ex.Message + "\n");

                return tradeEntity;
            }

            if (!Validate(tradeEntity))
            {
                return tradeEntity;
            }

            return tradeEntity;
        }


        private bool Validate(TradeEntity tradeEntity)
        {
            var validator = new CreateRequestValidator();
            var validationResult = validator.Validate(tradeEntity);

            if (!validationResult.IsValid)
                foreach (var error in validationResult.Errors)
                    Console.WriteLine(error.ErrorMessage);

            return validationResult.IsValid;
        }
    }
}
