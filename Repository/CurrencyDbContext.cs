using Application;
using CurrencyDomain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repository
{
    public class CurrencyDbContext : DbContext, ICurrencyDbContext
    {
        private readonly IConfiguration _configuration;

        public CurrencyDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Cube> Cubes { get; set; }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}