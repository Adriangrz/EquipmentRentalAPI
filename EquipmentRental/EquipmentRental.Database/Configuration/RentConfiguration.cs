using EquipmentRental.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Database.Configuration
{
    public class RentConfiguration : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.ToTable("Rents");

            builder.HasKey(x => x.RentId);

            builder.Property(x=>x.IsIssued).HasDefaultValue(false);
            builder.Property(x => x.IssuedDate).HasDefaultValue(null);

            builder.Property(x=>x.IsReturned).HasDefaultValue(false);
            builder.Property(x=>x.ReturnedDate).HasDefaultValue(null);

            builder.HasOne(r => r.SportEquipment)
                .WithOne(se => se.Rent)
                .HasForeignKey<Rent>(r => r.SportEquipmentId);
        }
    }
}
