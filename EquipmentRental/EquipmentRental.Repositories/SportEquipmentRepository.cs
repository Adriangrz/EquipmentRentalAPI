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
        public async Task DeleteAsync(Guid id)
        {
            SportEquipment? sportEquipment = await _context.SportsEquipment.SingleOrDefaultAsync(se => se.SportEquipmentId == id);
            if (sportEquipment is null) return;
            _context.SportsEquipment.Remove(sportEquipment);
        }

        public async Task<IEnumerable<SportEquipment>> GetAllAsync()
        {
            return await _context.SportsEquipment.ToListAsync();
        }

        public async Task InsertAsync(SportEquipment equipment)
        {
            await _context.SportsEquipment.AddAsync(equipment);
        }

        public void Update(SportEquipment equipment)
        {
            _context.SportsEquipment.Update(equipment);
        }
    }
}
