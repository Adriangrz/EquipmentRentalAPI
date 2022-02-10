using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        IRentRepository RentRepository { get; }
        ISportEquipmentRepository SportEquipmentRepository { get; }
        IUserRepository UserRepository { get; }
        Task Save();
    }
}
