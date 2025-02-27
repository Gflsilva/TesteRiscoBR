using TesteRiscoBR.Entidates;
using TesteRiscoBR.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteRiscoBR.Repository.Interface;
using TesteRiscoBR.Business;
using TesteRiscoBR.Repository;
using TesteRiscoBR.Business.Interface;

namespace TesteRiscoBR
{
    public class Classifier : IClassifier
    {
        ICategoryRepository _categoryRepository;

        public Classifier(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public string Classify(TradeEntity trade)
        {
            if ((trade.ReferenceDate - trade.NextPaymentDate).Days > 30)
            {
                return "EXPIRED";
            }
            else
            {

                var categoryEntity = _categoryRepository.GetCategories();

                categoryEntity.Add(new CategoryEntity()
                {
                    Id = categoryEntity.Count + 1,
                    Name = "HIGH_RISK",
                    Operator = ">",
                    Type = "PRIVATE",
                    Value = 1_000_000
                });

                categoryEntity.Add(new CategoryEntity()
                {
                    Id = categoryEntity.Count + 1,
                    Name = "MEDIUM_RISK",
                    Operator = ">",
                    Type = "PUBLIC",
                    Value = 1_000_000
                });


                foreach (var category in categoryEntity.Where(c => c.Type.ToLower() == trade.ClientSector.ToLower()).OrderByDescending(c => c.Value))
                {
                    if (trade.Category == "")
                    {
                        switch (category.Operator)
                        {
                            case ">":
                                trade.Category = trade.Value > category.Value ? category.Name : "";
                                break;
                            case "<":
                                trade.Category = trade.Value < category.Value ? category.Name : "";
                                break;
                            case "=":
                                trade.Category = trade.Value == category.Value ? category.Name : "";
                                break;
                            default:
                                trade.Category = "";
                                break;
                        }
                    }
                }

                return trade.Category;
            }
        }
    }
}
