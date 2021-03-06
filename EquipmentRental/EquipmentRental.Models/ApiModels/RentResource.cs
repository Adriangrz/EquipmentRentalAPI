using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Models.ApiModels
{
    public class RentResource
    {
        public Guid RentId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Street { get; set; }
        public bool IsIssued { get; set; }
        public DateTime? IssuedDate { get; set; }
        public bool IsReturned { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public Guid SportEquipmentId { get; set; }
        public Guid UserId { get; set; }
    }
}
