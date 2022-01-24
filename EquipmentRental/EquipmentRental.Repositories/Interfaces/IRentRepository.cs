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
        Task<IEnumerable<Rent>> GetAllAsync();
        Task<Rent?> FindByIdAsync(Guid id);
        Task InsertAsync(Rent rent);
        void Update(Rent rent);
    }
}
