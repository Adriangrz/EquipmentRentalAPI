using EquipmentRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Services.Communication
{
    public class RentsResponse : BaseResponse<IEnumerable<Rent>>
    {
        /// Creates a success response.
        public RentsResponse(IEnumerable<Rent> rents) : base(rents)
        { }

        /// Creates am error response.
        public RentsResponse(string message) : base(message)
        { }
    }
}
