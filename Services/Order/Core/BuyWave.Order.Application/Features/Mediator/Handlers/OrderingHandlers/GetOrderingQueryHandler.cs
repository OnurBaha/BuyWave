using BuyWave.Order.Application.Features.Mediator.Queries.OrderingQueries;
using BuyWave.Order.Application.Features.Mediator.Results.OrderingResults;
using BuyWave.Order.Application.Interfaces;
using BuyWave.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyWave.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class GetOrderingQueryHandler : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
{
    private readonly IRepository<Ordering> _repository;

    public GetOrderingQueryHandler(IRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetOrderingQueryResult
        {
            OrderingId = x.OrderingId,
            OrderDate = x.OrderDate,
            TotalPrice = x.TotalPrice,
            UserId = x.UserId
        }).ToList();
    }
}
