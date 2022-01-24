﻿using EquipmentRental.Models;
using EquipmentRental.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task InsertAsync(User user);
        void Update(User user);
        Task<UserResponse> DeleteAsync(Guid id);
    }
}
