using EquipmentRental.Models;
using EquipmentRental.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<UserResponse> InsertAsync(User user);
        Task<UserResponse> UpdateAsync(Guid id, User user);
        Task<UserResponse> DeleteAsync(Guid id);
    }
}
