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
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(EquipmentRentalContext context) : base(context)
        {
        }
        public async Task DeleteAsync(Guid id)
        {
            User? user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
            if (user is null) return;
            _context.Users.Remove(user);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task InsertAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }
        public void Update(User user)
        {
            _context.Users.Update(user);
        }
    }
}
