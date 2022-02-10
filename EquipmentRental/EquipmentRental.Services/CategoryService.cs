using EquipmentRental.Models;
using EquipmentRental.Repositories.Interfaces;
using EquipmentRental.Services.Communication;
using EquipmentRental.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRental.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryResponse> DeleteAsync(Guid id)
        {
            var existingCategory = await _unitOfWork.CategoryRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new CategoryResponse("Category not found.");

            try
            {
                _unitOfWork.CategoryRepository.Remove(existingCategory);
                await _unitOfWork.Save();

                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _unitOfWork.CategoryRepository.ListAsync();
        }

        public async Task<CategoryResponse> InsertAsync(Category category)
        {
            try
            {
                await _unitOfWork.CategoryRepository.AddAsync(category);
                await _unitOfWork.Save();

                return new CategoryResponse(category);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }
    }
}
