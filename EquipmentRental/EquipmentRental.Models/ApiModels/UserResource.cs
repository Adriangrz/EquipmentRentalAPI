using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Models.ApiModels
{
    public class UserResource
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
    }
}
