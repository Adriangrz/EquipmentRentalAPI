using EquipmentRental.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Database
{
    public class EquipmentRentalContext: DbContext
    {
        public EquipmentRentalContext()
        {
        }

        public EquipmentRentalContext(DbContextOptions<EquipmentRentalContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<SportEquipment> SportsEquipment { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
