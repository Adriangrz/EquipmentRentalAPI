using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Models.ApiModels
{
    public class SaveUpdateUserResource
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
    }
}
