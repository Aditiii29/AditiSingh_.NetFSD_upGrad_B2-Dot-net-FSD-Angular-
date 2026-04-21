using CategoryService.DTOs;
using CategoryService.Models;

namespace CategoryService.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Category> CreateAsync(CategoryDTO dto);
        Task<Category?> UpdateAsync(int id, CategoryDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}