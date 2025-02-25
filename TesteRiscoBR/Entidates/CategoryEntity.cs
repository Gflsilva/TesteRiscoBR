using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteRiscoBR.Entidates
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Tipo { get; set; }
        public int Operador { get; set; }
        public int Valor { get; set; }
    }
}
