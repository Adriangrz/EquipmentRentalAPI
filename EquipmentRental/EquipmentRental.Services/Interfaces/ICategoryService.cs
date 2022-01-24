using EquipmentRental.Models;
using EquipmentRental.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<CategoryResponse> InsertAsync(Category category);
        Task<CategoryResponse> DeleteAsync(Guid id);
    }
}
