using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteRiscoBR.Enum
{
    public enum TipoEnum
    {
        [Description("public")]
        PUBLIC,

        [Description("private")]
        PRIVATE
    }
}
