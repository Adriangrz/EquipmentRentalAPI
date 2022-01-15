using EquipmentRental.Database;
using EquipmentRental.Models;
using EquipmentRental.Repositories.Interfaces;
using EquipmentRental.Services.Communication;
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
        private readonly IUnitOfWork _unitOfWork;
        public RentService(IRentRepository rentRepository, IUnitOfWork unitOfWork)
        {
            _rentRepository = rentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Rent>> GetAllAsync()
        {
            return await _rentRepository.GetAllAsync();
        }

        public async Task<RentResponse> InsertAsync(Rent rent)
        {
            try
            {
                await _rentRepository.InsertAsync(rent);
                await _unitOfWork.Save();

                return new RentResponse(rent);
            }
            catch (Exception ex)
            {
                return new RentResponse($"An error occurred when saving the category: {ex.Message}");
            }
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
