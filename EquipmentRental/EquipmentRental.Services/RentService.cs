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
        private readonly IUnitOfWork _unitOfWork;
        public RentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Rent>> GetAllAsync()
        {
            return await _unitOfWork.RentRepository.ListAsync();
        }

        public async Task<RentsResponse> GetByUserIdAsync(Guid userId)
        {
            var rents =  await _unitOfWork.RentRepository.FindByUserIdAsync(userId);
            if(rents is null)
                return new RentsResponse($"Not found");
            return new RentsResponse(rents);
        }

        public async Task<RentResponse> InsertAsync(Rent rent)
        {
            var sportEquipment = await _unitOfWork.SportEquipmentRepository.FindByIdAsync(rent.SportEquipmentId);
            if (sportEquipment is null || !sportEquipment.IsAvailable)
                return new RentResponse("Sport equipment is not available");

            try
            {
                await _unitOfWork.RentRepository.AddAsync(rent);
                sportEquipment.IsAvailable = false;
                _unitOfWork.SportEquipmentRepository.Update(sportEquipment);
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
            var existingRent = await _unitOfWork.RentRepository.FindByIdAsync(id);
            if (existingRent is null)
                return new RentResponse("Rent not found.");

            existingRent.From = rent.From;
            existingRent.To = rent.To;
            existingRent.Name = rent.Name;
            existingRent.Surname = rent.Surname;
            existingRent.Street = rent.Street;
            existingRent.IsIssued = rent.IsIssued;
            existingRent.IssuedDate = rent.IssuedDate;
            existingRent.IsReturned = rent.IsReturned;
            existingRent.ReturnedDate = rent.ReturnedDate;
            existingRent.SportEquipmentId = rent.SportEquipmentId;
            existingRent.UserId = rent.UserId;

            try
            {
                _unitOfWork.RentRepository.Update(existingRent);
                await _unitOfWork.Save();

                return new RentResponse(existingRent);
            }
            catch (Exception ex)
            {
                return new RentResponse($"An error occurred when updating the rent: {ex.Message}");
            }
        }

        public async Task<RentResponse> UpdateIssuedAsync(Guid id, bool isIssued)
        {
            var existingRent = await _unitOfWork.RentRepository.FindByIdAsync(id);
            if (existingRent is null)
                return new RentResponse("Rent not found.");

            if (!isIssued)
                return new RentResponse(existingRent);

            existingRent.IsIssued = isIssued;
            existingRent.IssuedDate = DateTime.Now;

            try
            {
                _unitOfWork.RentRepository.Update(existingRent);
                await _unitOfWork.Save();

                return new RentResponse(existingRent);
            }
            catch (Exception ex)
            {
                return new RentResponse($"An error occurred when updating the rent: {ex.Message}");
            }
        }

        public async Task<RentResponse> UpdateReturnedAsync(Guid id, bool isReturned)
        {
            var existingRent = await _unitOfWork.RentRepository.FindByIdAsync(id);
            if (existingRent is null)
                return new RentResponse("Rent not found.");

            if (!isReturned)
                return new RentResponse(existingRent);

            var sportEquipment = await _unitOfWork.SportEquipmentRepository.FindByIdAsync(existingRent.SportEquipmentId);

            if (sportEquipment is null)
                return new RentResponse("SportEquipment in rent not found.");

            existingRent.IsReturned = isReturned;
            existingRent.ReturnedDate = DateTime.Now;
            sportEquipment.IsAvailable = true;

            try
            {
                _unitOfWork.RentRepository.Update(existingRent);
                _unitOfWork.SportEquipmentRepository.Update(sportEquipment);
                await _unitOfWork.Save();

                return new RentResponse(existingRent);
            }
            catch (Exception ex)
            {
                return new RentResponse($"An error occurred when updating the rent: {ex.Message}");
            }
        }

        public async Task<RentResponse> UpdateToAsync(Guid id, DateTime to)
        {
            var existingRent = await _unitOfWork.RentRepository.FindByIdAsync(id);
            if (existingRent is null)
                return new RentResponse("Rent not found.");

            existingRent.To = to;

            try
            {
                _unitOfWork.RentRepository.Update(existingRent);
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
