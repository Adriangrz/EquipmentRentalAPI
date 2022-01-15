using EquipmentRental.Database;
using EquipmentRental.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EquipmentRentalContext _context;

        public UnitOfWork(EquipmentRentalContext context)
        {
            _context = context;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
