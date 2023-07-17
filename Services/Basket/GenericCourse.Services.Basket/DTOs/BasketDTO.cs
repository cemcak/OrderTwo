using System.Linq;

namespace GenericCourse.Services.Basket.DTOs
{
    public class BasketDTO
    {
        public string UserId { get; set; }
        public string DiscountCode { get; set; }
        public List<BasketItemDTO> Items { get; set; }
        public decimal TotalPrice
        {
            get => Items.Sum(x => x.Price * x.Quantity);
        }
    }
}
