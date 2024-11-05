using BuyWave.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using BuyWave.Order.Application.Features.CQRS.Results.OrderDetailResults;
using BuyWave.Order.Application.Interfaces;
using BuyWave.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyWave.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

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
            ProductId = values.ProductId,
            ProductName = values.ProductName,
            OrderingId = values.OrderingId,
            ProductPrice = values.ProductPrice,
            ProductTotalPrice = values.ProductTotalPrice
        };
    }
}
