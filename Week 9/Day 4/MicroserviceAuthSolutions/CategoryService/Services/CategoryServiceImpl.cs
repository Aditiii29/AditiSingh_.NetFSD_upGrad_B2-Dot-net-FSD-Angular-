using CategoryService.DTOs;
using CategoryService.Models;
using CategoryService.Repositories;

namespace CategoryService.Services
{
    public class CategoryServiceImpl : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryServiceImpl(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
            => await _repository.GetAllAsync();

        public async Task<Category?> GetByIdAsync(int id)
            => await _repository.GetByIdAsync(id);

        public async Task<Category> CreateAsync(CategoryDTO dto)
        {
            var category = new Category
            {
                CategoryName = dto.CategoryName,
                Description = dto.Description
            };
            return await _repository.CreateAsync(category);
        }

        public async Task<Category?> UpdateAsync(int id, CategoryDTO dto)
        {
            var category = new Category
            {
                CategoryName = dto.CategoryName,
                Description = dto.Description
            };
            return await _repository.UpdateAsync(id, category);
        }

        public async Task<bool> DeleteAsync(int id)
            => await _repository.DeleteAsync(id);
    }
}