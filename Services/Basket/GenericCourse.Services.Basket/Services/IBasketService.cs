using GenericCourse.Services.Basket.DTOs;
using GenericCourse.Shared.DTOs;

namespace GenericCourse.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDTO>> Get(string userId);
        Task<Response<bool>> Upsert(BasketDTO basketDTO);
        Task<Response<bool>> Delete(string userId);
    }
}
