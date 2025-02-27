using TesteRiscoBR.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteRiscoBR.Entidates
{
    public class TradeEntity
    {
        public int Id { get; set; }
        public float Value { get; set; }
        public string ClientSector { get; set; }
        public DateTime NextPaymentDate { get; set; }
        public DateTime ReferenceDate { get; set; } = DateTime.Today;
        public string Category { get; set; } = string.Empty;
    }
}
