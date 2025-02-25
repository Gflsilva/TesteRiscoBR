using TesteRiscoBR.Entidates;
using TesteRiscoBR.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteRiscoBR
{
    public class TradeClassifier
    {
        public static TradeCategoryEnum Classify(TradeEntity trade, DateTime referenceDate)
        {
            if ((referenceDate - trade.NextPaymentDate).Days > 30)
                return TradeCategoryEnum.EXPIRED;

            if (trade.Value > 1_000_000)
            {
                return trade.ClientSector.ToLower() == "private" ? TradeCategoryEnum.HIGH_RISK : TradeCategoryEnum.MEDIUM_RISK;
            }



            return TradeCategoryEnum.MEDIUM_RISK;
        }
    }
}
