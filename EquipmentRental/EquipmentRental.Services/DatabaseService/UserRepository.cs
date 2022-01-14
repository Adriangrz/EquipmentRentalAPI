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
    public class UserRepository : IUser
    {
        private readonly EquipmentRentalContext _context;
        public UserRepository(EquipmentRentalContext context)
        {
            _context = context;
        }
        public async void Delete(Guid id)
        {
            User? user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
            if(user is null) return;
            _context.Users.Remove(user);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async void Insert(User user)
        {
            await _context.Users.AddAsync(user);
        }
        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public async void Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
