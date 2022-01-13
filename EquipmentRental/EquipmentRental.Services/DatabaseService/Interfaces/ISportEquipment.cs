using EquipmentRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Services.DatabaseService.Interfaces
{
    public interface ISportEquipment
    {
        IEnumerable<SportEquipment> GetAll();
        void Insert(SportEquipment equipment);
        void Update(SportEquipment equipment);
        void Delete(int id);
    }
}
