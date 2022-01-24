using EquipmentRental.Models;
using EquipmentRental.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Services.Interfaces
{
    public interface ISportEquipmentService
    {
        Task<IEnumerable<SportEquipment>> GetAllAsync();
        Task<SportEquipmentResponse> GetById(Guid id);
        Task<SportEquipmentResponse> InsertAsync(SportEquipment equipment);
        Task<SportEquipmentResponse> UpdateAsync(Guid id,SportEquipment equipment);
        Task<SportEquipmentResponse> DeleteAsync(Guid id);
    }
}
