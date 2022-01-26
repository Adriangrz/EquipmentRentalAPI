using EquipmentRental.Models;
using EquipmentRental.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Services.Interfaces
{
    public interface IJwtAuthService
    {
        Task<UserResponse> AuthenticationAsync(User loginCredentials);
        Guid? CheckUserId(Guid id, string userIdFromToken);
        string GenerateJWT(User userInfo);
    }
}
