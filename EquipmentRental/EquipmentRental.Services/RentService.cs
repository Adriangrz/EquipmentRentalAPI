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

namespace EquipmentRental.Services
{
    public class RentService : IRentService
    {
        private readonly IRentRepository _rentRepository;
        public RentService(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }

        public async Task<IEnumerable<Rent>> GetAllAsync()
        {
            return await _rentRepository.GetAllAsync();
        }

        public async Task InsertAsync(Rent rent)
        {
            await _rentRepository.InsertAsync(rent);
        }

        public void Update(Rent rent)
        {
            _rentRepository.Update(rent);
        }

        public async Task UpdateIssuedFieldAsync(Guid id, bool isIssued, DateTime issuedDate)
        {
            await _rentRepository.UpdateIssuedFieldAsync(id,isIssued,issuedDate);
        }

        public async Task UpdateReturnedFieldAsync(Guid id, bool isReturned, DateTime returnedDate)
        {
            await _rentRepository.UpdateReturnedFieldAsync(id, isReturned, returnedDate);
        }
    }
}
