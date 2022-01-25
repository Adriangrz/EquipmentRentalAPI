using EquipmentRental.Models;
using EquipmentRental.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Services.Interfaces
{
    public interface IRentService
    {
        Task<IEnumerable<Rent>> GetAllAsync();
        Task<RentResponse> InsertAsync(Rent rent);
        Task<RentResponse> UpdateAsync(Guid id,Rent rent);
        Task<RentResponse> UpdateIssuedAsync(Guid id, bool IsIssued);
        Task<RentResponse> UpdateReturnedAsync(Guid id, bool IsReturned);
    }
}
