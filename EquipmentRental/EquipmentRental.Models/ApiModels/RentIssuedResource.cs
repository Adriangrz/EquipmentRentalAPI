using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Models.ApiModels
{
    public class RentIssuedResource
    {
        public bool IsIssued { get; set; }
        public DateTime IssuedDate { get; set; }
    }
}
