using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyDomain.Models
{
    public class Cube
    {
        public Guid Id { get; set; }
        public decimal Rate { get; set; } = 0;

        public virtual Currency Currency { get; set; }
        public Guid CurrencyId { get; set; }
    }
}
