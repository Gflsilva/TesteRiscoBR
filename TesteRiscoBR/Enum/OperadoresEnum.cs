using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteRiscoBR.Enum
{
    public enum OperadoresEnum
    {
        [Description(">")]
        MAIOR = 1,

        [Description("<")]
        MENOR = 2,

        [Description("=")]
        IGUAL = 3
    }
}
