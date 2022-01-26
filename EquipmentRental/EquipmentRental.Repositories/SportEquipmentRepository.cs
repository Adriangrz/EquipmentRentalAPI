using EquipmentRental.Database;
using EquipmentRental.Models;
using EquipmentRental.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Repositories
{
    public class SportEquipmentRepository : BaseRepository, ISportEquipmentRepository
    {
        public SportEquipmentRepository(EquipmentRentalContext context) : base(context)
        {
        }
        public void Remove(SportEquipment sportEquipment)
        {
            _context.SportsEquipment.Remove(sportEquipment);
        }

        public async Task<IEnumerable<SportEquipment>> ListAsync()
        {
            return await _context.SportsEquipment.Where(x => x.IsAvailable != false).ToListAsync();
        }

        public async Task<SportEquipment?> FindByIdAsync(Guid id)
        {
            return await _context.SportsEquipment.FindAsync(id);
        }
        public async Task AddAsync(SportEquipment equipment)
        {
            await _context.SportsEquipment.AddAsync(equipment);
        }

        public void Update(SportEquipment equipment)
        {
            _context.SportsEquipment.Update(equipment);
        }
    }
}
