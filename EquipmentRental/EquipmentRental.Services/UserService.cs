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

namespace EquipmentRental.Services.DatabaseService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<UserResponse> DeleteAsync(Guid id)
        {
            var existingSportEquipment = await _userRepository.FindByIdAsync(id);

            if (existingSportEquipment is null)
                return new UserResponse("Sport equipment not found.");

            try
            {
                _userRepository.Remove(existingSportEquipment);
                await _unitOfWork.Save();

                return new UserResponse(existingSportEquipment);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error occurred when deleting the sport equipment: {ex.Message}");
            };
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task InsertAsync(User user)
        {
            await _userRepository.AddAsync(user);
        }
        public void Update(User user)
        {
            _userRepository.Update(user);
        }
    }
}
