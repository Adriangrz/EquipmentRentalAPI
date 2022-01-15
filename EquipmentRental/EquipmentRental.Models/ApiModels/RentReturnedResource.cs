using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Models.ApiModels
{
    public class RentReturnedResource
    {
        public bool IsReturned { get; set; }
        public DateTime ReturnedDate { get; set; }
    }
}
