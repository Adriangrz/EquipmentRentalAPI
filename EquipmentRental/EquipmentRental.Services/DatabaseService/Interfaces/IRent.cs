using EquipmentRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Services.DatabaseService.Interfaces
{
    public interface IRent
    {
        IEnumerable<Rent> GetAll();
        void Insert(Rent rent);
        void Update(Rent rent);
    }
}
