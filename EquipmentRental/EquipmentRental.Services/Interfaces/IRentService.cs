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
        void Update(Rent rent);
        Task UpdateIssuedFieldAsync(Guid id, bool isIssued, DateTime issuedDate);
        Task UpdateReturnedFieldAsync(Guid id, bool isReturned, DateTime returnedDate);
    }
}
