using EquipmentRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task<User?> FindByIdAsync(Guid id);
        Task AddAsync(User user);
        void Update(User user);
        void Remove(User user);
    }
}
