using TesteRiscoBR.Entidates;
using TesteRiscoBR.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using TesteRiscoBR.Repository.Interface;
using TesteRiscoBR.Business.Interface;
using TesteRiscoBR.Model.Trade.Create;

namespace TesteRiscoBR.Business
{
    public class TradeBusiness : ITradeBusiness
    {
        private ITradeRepository _tradeRepository;
        private IClassifierTrade _classifier;
        private TradeEntity tradeEntity;

        public TradeBusiness(ITradeRepository tradeRepository, IClassifierTrade classifier)
        {
            _tradeRepository = tradeRepository;
            _classifier = classifier;
        }

        public List<TradeEntity> ConsultarCategorias()
        {
            List<TradeEntity> trades = _tradeRepository.GetTrades();

            return trades;
        }

        public void AddTrade()
        {
            tradeEntity = new TradeEntity();

            tradeEntity = PreencherCampos(tradeEntity);

            if (tradeEntity.Erros)
            {
                _tradeRepository.AddTrade(tradeEntity);
                Console.WriteLine("Trade cadastrada com sucesso!");
            }
            else
            {
                Console.WriteLine("\nVerifique as informações preenchidas!\n");
            }
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
                tradeEntity.Value = decimal.Parse(Console.ReadLine());

                Console.Write("Digite o setor do cliente (PUBLIC/PRIVATE): ");
                tradeEntity.ClientSector = Console.ReadLine();

                Console.Write("Digite a data do próximo pagamento (MM/dd/yyyy): ");
                tradeEntity.NextPaymentDate = DateTime.Parse(Console.ReadLine());

                tradeEntity.Category = _classifier.Classify(tradeEntity);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nVerifique as informações preenchidas. " + ex.Message + "\n");

                return tradeEntity;
            }

            tradeEntity.Erros = Validate(tradeEntity);

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

        public void ProcessTradesInBatches(List<TradeEntity> trades, int batchSize = 10)
        {
            for (int i = 0; i < trades.Count; i += batchSize)
            {
                var batch = trades.Skip(i).Take(batchSize).ToList();
                foreach (var trade in batch)
                {
                    trade.Category = _classifier.Classify(trade);
                    _tradeRepository.AddTrade(trade);
                }
                Console.WriteLine($"Lote de {batch.Count} trades processado.");
            }
        }

        public void TradeClassifier()
        {
            List<TradeEntity> retorno = ConsultarCategorias();

            if (retorno.Count == 0)
            {
                Console.WriteLine("\nNão existem categorias cadastradas!\n");
                return;
            }

            foreach (var item in retorno)
            {
                item.Category = _classifier.Classify(item);

                _tradeRepository.UpdateTrade(item);
            }
        }
    }
}
