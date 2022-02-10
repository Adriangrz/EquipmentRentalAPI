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
    public class SportEquipmentService : ISportEquipmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SportEquipmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SportEquipmentResponse> DeleteAsync(Guid id)
        {
            var existingSportEquipment = await _unitOfWork.SportEquipmentRepository.FindByIdAsync(id);

            if (existingSportEquipment is null)
                return new SportEquipmentResponse("Sport equipment not found.");

            try
            {
                _unitOfWork.SportEquipmentRepository.Remove(existingSportEquipment);
                await _unitOfWork.Save();

                return new SportEquipmentResponse(existingSportEquipment);
            }
            catch (Exception ex)
            {
                return new SportEquipmentResponse($"An error occurred when deleting the sport equipment: {ex.Message}");
            }
        }

        public async Task<IEnumerable<SportEquipment>> GetAllAsync()
        {
            return await _unitOfWork.SportEquipmentRepository.ListAsync();
        }

        public async Task<SportEquipmentResponse> GetById(Guid id)
        {
            var existingSportEquipment = await _unitOfWork.SportEquipmentRepository.FindByIdAsync(id);

            if (existingSportEquipment is null)
                return new SportEquipmentResponse("Sport equipment not found.");

            return new SportEquipmentResponse(existingSportEquipment);
        }

        public async Task<SportEquipmentResponse> InsertAsync(SportEquipment equipment)
        {
            try
            {
                await _unitOfWork.SportEquipmentRepository.AddAsync(equipment);
                await _unitOfWork.Save();

                return new SportEquipmentResponse(equipment);
            }
            catch (Exception ex)
            {
                return new SportEquipmentResponse($"An error occurred when saving the sport equipment: {ex.Message}");
            }
        }

        public async Task<SportEquipmentResponse> UpdateAsync(Guid id, SportEquipment equipment)
        {
            var existingSportEquipment = await _unitOfWork.SportEquipmentRepository.FindByIdAsync(id);
            if (existingSportEquipment is null)
                return new SportEquipmentResponse("Sport equipment not found.");

            existingSportEquipment.Name = equipment.Name;
            existingSportEquipment.PriceForDay = equipment.PriceForDay;
            existingSportEquipment.IsAvailable = equipment.IsAvailable;
            existingSportEquipment.CategoryId = equipment.CategoryId;

            try
            {
                _unitOfWork.SportEquipmentRepository.Update(existingSportEquipment);
                await _unitOfWork.Save();

                return new SportEquipmentResponse(existingSportEquipment);
            }
            catch (Exception ex)
            {
                return new SportEquipmentResponse($"An error occurred when updating the sport equipment: {ex.Message}");
            }
        }
    }
}
