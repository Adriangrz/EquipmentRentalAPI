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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryResponse> DeleteAsync(Guid id)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new CategoryResponse("Category not found.");

            try
            {
                _categoryRepository.Remove(existingCategory);
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
            return await _categoryRepository.ListAsync();
        }

        public async Task<CategoryResponse> InsertAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
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
