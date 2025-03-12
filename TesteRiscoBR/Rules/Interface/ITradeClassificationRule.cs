using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteRiscoBR.Entidates;

namespace TesteRiscoBR.Business.Interface
{
    public interface ITradeClassificationRule
    {
        public bool ApplyRule(TradeEntity trade, out string category);
    }
}
