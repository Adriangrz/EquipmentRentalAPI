using EquipmentRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Repositories.Interfaces
{
    public interface IRentRepository
    {
        Task<IEnumerable<Rent>> ListAsync();
        Task<IEnumerable<Rent>?> FindByUserIdAsync(Guid userId);
        Task<Rent?> FindByIdAsync(Guid id);
        Task AddAsync(Rent rent);
        void Update(Rent rent);
    }
}
