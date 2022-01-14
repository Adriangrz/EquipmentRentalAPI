using EquipmentRental.Database;
using EquipmentRental.Models;
using EquipmentRental.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Services.DatabaseService
{
    public class SportEquipmentRepository : ISportEquipment
    {
        private readonly EquipmentRentalContext _context;
        public SportEquipmentRepository(EquipmentRentalContext context)
        {
            _context = context;
        }

        public async void Delete(Guid id)
        {
            SportEquipment? sportEquipment = await _context.SportsEquipment.SingleOrDefaultAsync(se => se.SportEquipmentId == id);
            if (sportEquipment is null) return;
            _context.SportsEquipment.Remove(sportEquipment);
        }

        public async Task<IEnumerable<SportEquipment>> GetAll()
        {
            return await _context.SportsEquipment.ToListAsync();
        }

        public async void Insert(SportEquipment equipment)
        {
            await _context.SportsEquipment.AddAsync(equipment);
        }

        public void Update(SportEquipment equipment)
        {
            _context.SportsEquipment.Update(equipment);
        }

        public async void Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
