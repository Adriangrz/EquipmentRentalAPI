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
    public class RentRepository : IRent
    {
        private readonly EquipmentRentalContext _context;
        public RentRepository(EquipmentRentalContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rent>> GetAll()
        {
            return await _context.Rents.ToListAsync();
        }

        public async void Insert(Rent rent)
        {
            await _context.Rents.AddAsync(rent);
        }

        public void Update(Rent rent)
        {
            _context.Rents.Update(rent);
        }

        public async void UpdateIssuedField(Guid id, bool isIssued, DateTime issuedDate)
        {
            Rent? rent = await _context.Rents.SingleOrDefaultAsync(se => se.SportEquipmentId == id);
            if (rent is null) return;
            rent.IsIssued = isIssued;
            rent.IssuedDate = issuedDate;
            _context.Rents.Update(rent);
        }

        public async void UpdateReturnedField(Guid id, bool isReturned, DateTime returnedDate)
        {
            Rent? rent = await _context.Rents.SingleOrDefaultAsync(se => se.SportEquipmentId == id);
            if (rent is null) return;
            rent.IsReturned = isReturned;
            rent.ReturnedDate = returnedDate;
            _context.Rents.Update(rent);
        }
        public async void Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
