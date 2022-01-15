using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Models.ApiModels
{
    public class CategoryResource
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
