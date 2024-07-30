using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyDomain.Models
{
    public class Currency
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual required ICollection<Cube> Cubes { get; set; }
    }
}
