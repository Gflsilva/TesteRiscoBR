using TesteRiscoBR.Entidates;
using TesteRiscoBR.Business.Interface;

public class ExpiredTradeRule : ITradeClassificationRule
{
    public bool ApplyRule(TradeEntity trade, out string category)
    {
        if ((trade.ReferenceDate - trade.NextPaymentDate).Days > 30)
        {
            category = "EXPIRED";
            return true;
        }
        category = string.Empty;
        return false;
    }
}
