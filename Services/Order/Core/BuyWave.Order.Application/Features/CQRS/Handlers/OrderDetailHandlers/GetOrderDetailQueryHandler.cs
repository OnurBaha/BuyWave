using BuyWave.Order.Application.Features.CQRS.Results.OrderDetailResults;
using BuyWave.Order.Application.Interfaces;
using BuyWave.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyWave.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class GetOrderDetailQueryHandler
{
    private readonly IRepository<OrderDetail> _repository;

    public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
    {
        _repository = repository;
    }
    public async Task<List<GetOrderDetailQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetOrderDetailQueryResult
        {
            OrderDetailId = x.OrderDetailId,
            ProductAmount = x.ProductAmount,
            OrderingId = x.OrderingId,
            ProductId = x.ProductId,
            ProductName = x.ProductName,
            ProductPrice = x.ProductPrice,
            ProductTotalPrice = x.ProductTotalPrice
        }).ToList();
    }
}
