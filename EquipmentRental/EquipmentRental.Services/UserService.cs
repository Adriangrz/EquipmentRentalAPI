using EquipmentRental.Database;
using EquipmentRental.Models;
using EquipmentRental.Repositories.Interfaces;
using EquipmentRental.Services.Communication;
using EquipmentRental.Services.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            var existingUser = await _userRepository.FindByIdAsync(id);

            if (existingUser is null)
                return new UserResponse("User not found.");

            try
            {
                _userRepository.Remove(existingUser);
                await _unitOfWork.Save();

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error occurred when deleting the user: {ex.Message}");
            };
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<UserResponse> InsertAsync(User user)
        {
            var existingUser = await _userRepository.FindByNameAsync(user.Name);
            if (existingUser is not null)
                return new UserResponse("User name exist.");

            try
            {
                byte[] salt = new byte[128 / 8];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetNonZeroBytes(salt);
                }

                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: user.Password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));

                user.Password = hashed;
                user.Salt = Convert.ToBase64String(salt);

                await _userRepository.AddAsync(user);
                await _unitOfWork.Save();

                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error occurred when saving the user: {ex.Message}");
            }
        }
        public async Task<UserResponse> UpdateAsync(Guid id, User user)
        {
            var existingUser = await _userRepository.FindByIdAsync(id);
            if (existingUser is null)
                return new UserResponse("User not found.");

            var existingUserWithThisName = await _userRepository.FindByNameAsync(user.Name);
            if (existingUserWithThisName is not null)
                return new UserResponse("User name exist.");

            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetNonZeroBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: user.Password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            existingUser.Name = user.Name;
            existingUser.Password = hashed;
            existingUser.Salt = Convert.ToBase64String(salt);

            try
            {
                _userRepository.Update(existingUser);
                await _unitOfWork.Save();

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error occurred when updating the user: {ex.Message}");
            }
        }
    }
}
