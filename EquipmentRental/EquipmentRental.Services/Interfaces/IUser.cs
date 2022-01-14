using EquipmentRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Services.Interfaces
{
    public interface IUser
    {
        Task<IEnumerable<User>> GetAll();
        void Insert(User user);
        void Update(User user);
        void Delete(Guid id);
        void Save();
    }
}
