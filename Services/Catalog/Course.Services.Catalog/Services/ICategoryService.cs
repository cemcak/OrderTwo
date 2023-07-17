using GenericCourse.Services.Catalog.DTOs;
using GenericCourse.Services.Catalog.Models;
using GenericCourse.Shared.DTOs;

namespace GenericCourse.Services.Catalog.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDTO>>> GetAllAsync();
        Task<Response<CategoryDTO>> CreateAsync(CategoryDTO category);
        Task<Response<CategoryDTO>> GetByIdAsync(string id);

    }
}
