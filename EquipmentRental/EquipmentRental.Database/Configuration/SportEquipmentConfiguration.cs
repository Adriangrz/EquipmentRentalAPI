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
    public class SportEquipmentConfiguration : IEntityTypeConfiguration<SportEquipment>
    {
        public void Configure(EntityTypeBuilder<SportEquipment> builder)
        {
            builder.ToTable("SportsEquipment");

            builder.HasKey(x => x.SportEquipmentId);

            builder.HasOne(se => se.Category)
                .WithMany(ca => ca.SportsEquipment)
                .HasForeignKey(se => se.CategoryId);
        }
    }
}
