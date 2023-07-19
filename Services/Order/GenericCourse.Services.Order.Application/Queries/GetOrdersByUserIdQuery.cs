using GenericCourse.Services.Order.Application.DTOs;
using GenericCourse.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCourse.Services.Order.Application.Queries
{
    public class GetOrdersByUserIdQuery : IRequest<Response<List<OrderDTO>>>
    {
        public string UserId { get; set; }
    }
}
