using TesteRiscoBR.Entidates;
using System.Collections.Generic;
using TesteRiscoBR.Business.Interface;

namespace TesteRiscoBR.Business
{
    public class ClassifierTrade : IClassifierTrade
    {
        private readonly List<ITradeClassificationRule> _rules;

        public ClassifierTrade(IEnumerable<ITradeClassificationRule> rules)
        {
            _rules = new List<ITradeClassificationRule>(rules);
        }

        public string Classify(TradeEntity trade)
        {
            foreach (var rule in _rules)
            {
                if (rule.ApplyRule(trade, out string category))
                {
                    return category;
                }
            }
            return "UNCATEGORIZED";
        }
    }
}
