using Application.Clients.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.GetCurrencies
{
    public class GetCurrencyResponse
    {
        public List<CurrencyCube> CurrencyList { get; set; }
    }
}
