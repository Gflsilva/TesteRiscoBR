using TesteRiscoBR.Entidates;
using TesteRiscoBR.Business.Interface;
public class MediumRiskTradeRule : ITradeClassificationRule
{
    public bool ApplyRule(TradeEntity trade, out string category)
    {
        if (trade.ClientSector == "PUBLIC" && trade.Value > 1000000)
        {
            category = "MEDIUM_RISK";
            return true;
        }
        category = string.Empty;
        return false;
    }
}
