using CurrencyDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public interface ICurrencyDbContext
    {
        DbSet<Currency> Currencies { get; set; }
        DbSet<Cube> Cubes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}