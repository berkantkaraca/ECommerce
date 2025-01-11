using ECommerce.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using ECommerce.Order.Application.Features.CQRS.Result.OrderDetailResuts;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;

namespace ECommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);

            return new GetOrderDetailByIdQueryResult
            {
                OrderDetailId = values.OrderDetailId,
                ProductAmount = values.ProductAmount,
                OrderingId = values.OrderingId,
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                ProductPrice = values.ProductPrice,
                ProductTotalPrice = values.ProductTotalPrice,
            };
        }
    }
}
