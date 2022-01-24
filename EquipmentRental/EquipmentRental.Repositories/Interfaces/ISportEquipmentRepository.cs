using EquipmentRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Repositories.Interfaces
{
    public interface ISportEquipmentRepository
    {
        Task<IEnumerable<SportEquipment>> ListAsync();
        Task<SportEquipment?> FindByIdAsync(Guid id);
        Task AddAsync(SportEquipment equipment);
        void Update(SportEquipment equipment);
        void Remove(SportEquipment sportEquipment);
    }
}
