using EquipmentRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Services.Communication
{
    public class CategoryResponse : BaseResponse<Category>
    {
        /// Creates a success response.
        public CategoryResponse(Category category) : base(category)
        { }

        /// Creates am error response.
        public CategoryResponse(string message) : base(message)
        { }
    }
}
