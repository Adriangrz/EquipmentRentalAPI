using EquipmentRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<Category?> FindByIdAsync(Guid id);
        Task AddAsync(Category category);
        void Remove(Category category);
    }
}
