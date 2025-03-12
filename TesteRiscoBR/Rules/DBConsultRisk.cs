using TesteRiscoBR.Entidates;
using TesteRiscoBR.Business.Interface;
using TesteRiscoBR.Repository;
using TesteRiscoBR.Repository.Interface;
public class DBConsultRisk : ITradeClassificationRule
{
    private ICategoryRepository _categoryRepository;

    public DBConsultRisk(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public bool ApplyRule(TradeEntity trade, out string category)
    {
        var categoryEntity = _categoryRepository.GetCategories();


        foreach (var categoryItem in categoryEntity.Where(c => c.Type.ToLower() == trade.ClientSector.ToLower()).OrderByDescending(c => c.Value))
        {
            switch (categoryItem.Operator)
            {
                case ">":
                    trade.Category = trade.Value > categoryItem.Value ? categoryItem.Name : "";
                    break;
                case "<":
                    trade.Category = trade.Value < categoryItem.Value ? categoryItem.Name : "";
                    break;
                case "=":
                    trade.Category = trade.Value == categoryItem.Value ? categoryItem.Name : "";
                    break;
                default:
                    trade.Category = "";
                    break;
            }
        }

        if (!string.IsNullOrEmpty(trade.Category))
        {
            category = trade.Category;
            return true;
        }
        category = string.Empty;
        return false;
    }
}
