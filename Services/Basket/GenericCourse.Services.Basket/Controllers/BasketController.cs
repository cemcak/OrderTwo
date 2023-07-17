using GenericCourse.Services.Basket.DTOs;
using GenericCourse.Services.Basket.Services;
using GenericCourse.Shared.BaseController;
using GenericCourse.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenericCourse.Services.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : CustomBaseController
    {
        private readonly IBasketService _basketService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public BasketController(IBasketService basketService, ISharedIdentityService sharedIdentityService)
        {
            _basketService = basketService;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return CreateActionResultInstance(await _basketService.Get(_sharedIdentityService.GetUserId));
        }
        [HttpPost]
        public async Task<IActionResult> Upsert(BasketDTO basketDTO)
        {
            var response = await _basketService.Upsert(basketDTO);

            return CreateActionResultInstance(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return CreateActionResultInstance(await _basketService.Delete(_sharedIdentityService.GetUserId));
        }
    }
}
