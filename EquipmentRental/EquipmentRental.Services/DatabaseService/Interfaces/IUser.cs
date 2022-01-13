using EquipmentRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Services.DatabaseService.Interfaces
{
    public interface IUser
    {
        IEnumerable<User> GetAll();
        void Insert(User user);
        void Update(User user);
        void Delete(User user);
    }
}
