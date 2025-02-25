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
    public interface ITradeBusiness
    {
        public void AddTrade(TradeRepository repository);

        public void RemoveTrades(TradeRepository repository);

        public void ListTrades(TradeRepository repository);
    }
}
