﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteRiscoBR.Enum;

namespace TesteRiscoBR.Entidates
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Operator { get; set; }
        public decimal Value { get; set; }
        public bool Erros { get; set; }
    }
}
