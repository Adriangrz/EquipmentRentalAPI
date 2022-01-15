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
    public class RentRepository : BaseRepository, IRentRepository
    {
        public RentRepository(EquipmentRentalContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Rent>> GetAllAsync()
        {
            return await _context.Rents.ToListAsync();
        }

        public async Task InsertAsync(Rent rent)
        {
            await _context.Rents.AddAsync(rent);
        }

        public void Update(Rent rent)
        {
            _context.Rents.Update(rent);
        }

        public async Task UpdateIssuedFieldAsync(Guid id, bool isIssued, DateTime issuedDate)
        {
            Rent? rent = await _context.Rents.SingleOrDefaultAsync(se => se.SportEquipmentId == id);
            if (rent is null) return;
            rent.IsIssued = isIssued;
            rent.IssuedDate = issuedDate;
            _context.Rents.Update(rent);
        }

        public async Task UpdateReturnedFieldAsync(Guid id, bool isReturned, DateTime returnedDate)
        {
            Rent? rent = await _context.Rents.SingleOrDefaultAsync(se => se.SportEquipmentId == id);
            if (rent is null) return;
            rent.IsReturned = isReturned;
            rent.ReturnedDate = returnedDate;
            _context.Rents.Update(rent);
        }
    }
}
