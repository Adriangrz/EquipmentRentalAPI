using EquipmentRental.Models;
using EquipmentRental.Services.DatabaseService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Services.DatabaseService
{
    public class RentRepository : IRent
    {
        public IEnumerable<Rent> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Rent rent)
        {
            throw new NotImplementedException();
        }

        public void Update(Rent rent)
        {
            throw new NotImplementedException();
        }
    }
}
