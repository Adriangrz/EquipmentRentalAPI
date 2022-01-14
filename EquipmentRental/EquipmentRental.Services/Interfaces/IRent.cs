using EquipmentRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Services.Interfaces
{
    public interface IRent
    {
        Task<IEnumerable<Rent>> GetAll();
        void Insert(Rent rent);
        void Update(Rent rent);
        void UpdateIssuedField(Guid id, bool isIssued, DateTime issuedDate);
        void UpdateReturnedField(Guid id, bool isReturned, DateTime returnedDate);
        void Save();
    }
}
