using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Models.ApiModels
{
    public class SaveUpdateSportEquipmentResource
    {
        public string Name { get; set; }
        public decimal PriceForDay { get; set; }
        public bool IsAvailable { get; set; }
        public Guid CategoryId { get; set; }
    }
}
