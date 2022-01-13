using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Models
{
    public class SportEquipment
    {
        public Guid SportEquipmentId { get; set; }
        public string Name { get; set; }
        public decimal PriceForDay { get; set; }
        public bool IsAvailable { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Rent Rent { get; set; }
    }
}
