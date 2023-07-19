using GenericCourse.Services.Order.Application.Commands;
using GenericCourse.Services.Order.Application.DTOs;
using GenericCourse.Services.Order.Domain.OrderAggregate;
using GenericCourse.Services.Order.Infrastructure;
using GenericCourse.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCourse.Services.Order.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<CreatedOrderDTO>>
    {
        private readonly OrderDbContext _orderDbContext;

        public CreateOrderCommandHandler(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task<Response<CreatedOrderDTO>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var address = new Address
                (
                    request.Address.Province, request.Address.District, request.Address.Street, request.Address.ZipCode, request.Address.Line
                );

            Domain.OrderAggregate.Order newOrder = new Domain.OrderAggregate.Order(address, request.BuyerId);

            request.OrderItems.ForEach(x =>
            {
                newOrder.AddOrderItem(x.ProductId, x.ProductName, x.Price, x.Quantity);
            });

            await _orderDbContext.Orders.AddAsync(newOrder);

            await _orderDbContext.SaveChangesAsync();

            return Response<CreatedOrderDTO>.Success(new CreatedOrderDTO { OrderId = newOrder.Id }, 200);
        }
    }
}
