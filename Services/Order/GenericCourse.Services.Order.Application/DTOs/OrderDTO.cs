using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCourse.Services.Order.Application.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public AddressDTO Address { get; set; }
        public string BuyerId { get; set; }

        public ICollection<OrderItemDTO> OrderItems { get; set; }
    }
}
