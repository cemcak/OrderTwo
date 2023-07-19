using GenericCourse.Services.Order.Application.DTOs;
using GenericCourse.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCourse.Services.Order.Application.Commands
{
    public class CreateOrderCommand : IRequest<Response<CreatedOrderDTO>>
    {
        [Required]
        public string BuyerId { get; set; }
        [Required]
        public List<OrderItemDTO> OrderItems { get; set; }
        [Required]
        public AddressDTO Address { get; set; }
    }
}
