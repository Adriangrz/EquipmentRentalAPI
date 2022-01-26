using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Models.ApiModels
{
    public class ReturnedUserResource
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
    }
}
