﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteRiscoBR.Entidates;

namespace TesteRiscoBR.Business.Interface
{
    public interface IClassifierTrade
    {
        public string Classify(TradeEntity trade);
    }
}
