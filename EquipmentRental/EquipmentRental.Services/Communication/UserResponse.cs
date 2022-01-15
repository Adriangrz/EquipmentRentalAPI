using EquipmentRental.Models;

namespace EquipmentRental.Services.Communication
{
    public class UserResponse : BaseResponse<User>
    {
        /// Creates a success response.
        public UserResponse(User user) : base(user)
        { }

        /// Creates am error response.
        public UserResponse(string message) : base(message)
        { }
    }
}
