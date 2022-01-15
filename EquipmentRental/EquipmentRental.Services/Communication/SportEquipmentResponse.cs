using EquipmentRental.Models;

namespace EquipmentRental.Services.Communication
{
    public class SportEquipmentResponse : BaseResponse<SportEquipment>
    {
        /// Creates a success response.
        public SportEquipmentResponse(SportEquipment sportEquipment) : base(sportEquipment)
        { }

        /// Creates am error response.
        public SportEquipmentResponse(string message) : base(message)
        { }
    }
}
