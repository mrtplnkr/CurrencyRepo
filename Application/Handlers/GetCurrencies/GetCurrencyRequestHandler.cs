using Application.Clients;
using Application.Clients.Extensions;
using CubeExample;
using CurrencyDomain.Models;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Application.Handlers.GetCurrencies
{
    public class GetCurrencyRequestHandler : IRequestHandler<GetCurrencyRequest, GetCurrencyResponse>
    {
        private readonly ICurrencyHttpClient _httpHandler;
        private readonly IConfigurationSection _config;

        private readonly ICurrencyDbContext _db;

        public GetCurrencyRequestHandler(ICurrencyHttpClient client, IConfiguration configRoot, ICurrencyDbContext db)
        {
            _httpHandler = client;
            _config = configRoot.GetSection("HttpConfig");
            _db = db;
        }

        public async ValueTask<GetCurrencyResponse> Handle(GetCurrencyRequest request, CancellationToken cancellationToken)
        {
            string xml = await _httpHandler.Get($"{_config["ServiceApiBase"]}/eurofxref-daily.xml?27b998b67243093250c881b33d6a433b");

            RootCube rootCube = xml.DeserializeWithoutEnvelope<RootCube>($"{_config["NamespaceUri"]}", "Cube");

            if (rootCube.TimeCubes.FirstOrDefault() == null)
            {
                throw new Exception("Server Error");
            }
            else
            {
                var currencyId = Guid.NewGuid();
                _db.Currencies.Add(new Currency() { 
                    Id = currencyId,
                    Name = "",
                    Cubes = rootCube.TimeCubes.First().CurrencyCubes.Select(x => new Cube()
                    {
                        Id = Guid.NewGuid(),
                        Rate = x.Rate,
                        CurrencyId = currencyId,
                    }).ToList()
                });

                //await _db.Currencies.SaveChanges;

                //store CurrencyCube to the database
                return new GetCurrencyResponse
                {
                    CurrencyList = rootCube.TimeCubes.First().CurrencyCubes
                };
            }
        }
    }
}
