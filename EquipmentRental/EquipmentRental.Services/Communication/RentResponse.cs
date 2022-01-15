using EquipmentRental.Models;

namespace EquipmentRental.Services.Communication
{
    public class RentResponse : BaseResponse<Rent>
    {
        /// Creates a success response.
        public RentResponse(Rent rent) : base(rent)
        { }

        /// Creates am error response.
        public RentResponse(string message) : base(message)
        { }
    }
}
