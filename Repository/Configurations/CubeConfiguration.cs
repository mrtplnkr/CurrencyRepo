using CurrencyDomain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configurations
{
    public class CubeConfiguration : IEntityTypeConfiguration<Cube>
    {
        public void Configure(EntityTypeBuilder<Cube> builder)
        {
            builder.HasOne(x => x.Currency)
                .WithMany(x => x.Cubes)
                .HasForeignKey(x => x.CurrencyId);
        }
    }
}
