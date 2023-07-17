using GenericCourse.Services.Basket.DTOs;
using GenericCourse.Shared.DTOs;
using System.Text.Json;

namespace GenericCourse.Services.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<Response<bool>> Delete(string userId)
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(userId);

            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Basket not found", 404);
        }

        public async Task<Response<BasketDTO>> Get(string userId)
        {
            var basket = await _redisService.GetDb().StringGetAsync(userId);

            if (String.IsNullOrEmpty(basket))
                return Response<BasketDTO>.Fail("Basket not found", 404);

            return Response<BasketDTO>.Success(JsonSerializer.Deserialize<BasketDTO>(basket), 200);

        }

        public async Task<Response<bool>> Upsert(BasketDTO basketDTO)
        {
            var status = await _redisService.GetDb().StringSetAsync(basketDTO.UserId, JsonSerializer.Serialize(basketDTO));

            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Upsert failed", 500);
        }
    }
}
