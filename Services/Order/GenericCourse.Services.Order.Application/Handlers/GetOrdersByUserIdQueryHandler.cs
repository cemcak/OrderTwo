using GenericCourse.Services.Order.Application.DTOs;
using GenericCourse.Services.Order.Application.Mapping;
using GenericCourse.Services.Order.Application.Queries;
using GenericCourse.Services.Order.Infrastructure;
using GenericCourse.Shared.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCourse.Services.Order.Application.Handlers
{
    public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, Response<List<OrderDTO>>>
    {
        private readonly OrderDbContext _orderDbContext;

        public GetOrdersByUserIdQueryHandler(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task<Response<List<OrderDTO>>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderDbContext.Orders.Include(x => x.OrderItems).Where(x => x.BuyerId == request.UserId).ToListAsync();

            if (!orders.Any())
                return Response<List<OrderDTO>>.Success(new List<OrderDTO>(), 200);

            var ordersDTO = ObjectMapper.Mapper.Map<List<OrderDTO>>(orders);

            return Response<List<OrderDTO>>.Success(ordersDTO, 200);
        }
    }
}
