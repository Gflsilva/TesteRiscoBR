using TesteRiscoBR.Entidates;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteRiscoBR.Repository.Interface
{
    public interface ITradeRepository
    {
        public void LoadTrades();

        public void SaveTrades();

        public void AddTrade(TradeEntity trade);

        public void RemoveTrades(int tradeId);

        public List<TradeEntity> GetTrades();
    }
}
