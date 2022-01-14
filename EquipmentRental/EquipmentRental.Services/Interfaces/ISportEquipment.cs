using EquipmentRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Services.Interfaces
{
    public interface ISportEquipment
    {
        Task<IEnumerable<SportEquipment>> GetAll();
        void Insert(SportEquipment equipment);
        void Update(SportEquipment equipment);
        void Delete(Guid id);
        void Save();
    }
}
