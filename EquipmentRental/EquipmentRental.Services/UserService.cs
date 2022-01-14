using EquipmentRental.Database;
using EquipmentRental.Database.Repositories.Interfaces;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task DeleteAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task InsertAsync(User user)
        {
            await _userRepository.InsertAsync(user);
        }
        public void Update(User user)
        {
            _userRepository.Update(user);
        }
    }
}
