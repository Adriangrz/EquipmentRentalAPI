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
            return await _rentRepository.ListAsync();
        }

        public async Task<RentResponse> InsertAsync(Rent rent)
        {
            try
            {
                await _rentRepository.AddAsync(rent);
                await _unitOfWork.Save();

                return new RentResponse(rent);
            }
            catch (Exception ex)
            {
                return new RentResponse($"An error occurred when saving the rent: {ex.Message}");
            }
        }

        public async Task<RentResponse> UpdateAsync(Guid id,Rent rent)
        {
            var existingRent = await _rentRepository.FindByIdAsync(id);
            if (existingRent is null)
                return new RentResponse("Rent not found.");

            existingRent.From = rent.From;
            existingRent.To = rent.To;
            existingRent.IsIssued = rent.IsIssued;
            existingRent.IssuedDate = rent.IssuedDate;
            existingRent.IsReturned = rent.IsReturned;
            existingRent.ReturnedDate = rent.ReturnedDate;
            existingRent.SportEquipmentId = rent.SportEquipmentId;

            try
            {
                _rentRepository.Update(existingRent);
                await _unitOfWork.Save();

                return new RentResponse(existingRent);
            }
            catch (Exception ex)
            {
                return new RentResponse($"An error occurred when updating the rent: {ex.Message}");
            }
        }
    }
}
