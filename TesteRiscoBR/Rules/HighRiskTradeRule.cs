using TesteRiscoBR.Entidates;
using TesteRiscoBR.Business.Interface;
public class HighRiskTradeRule : ITradeClassificationRule
{
    public bool ApplyRule(TradeEntity trade, out string category)
    {
        if (trade.ClientSector == "PRIVATE" && trade.Value > 1000000)
        {
            category = "HIGH_RISK";
            return true;
        }
        category = string.Empty;
        return false;
    }
}
