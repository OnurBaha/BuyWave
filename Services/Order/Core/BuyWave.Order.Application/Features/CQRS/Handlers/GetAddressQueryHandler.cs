using BuyWave.Order.Application.Features.CQRS.Results.AddressResults;
using BuyWave.Order.Application.Interfaces;
using BuyWave.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyWave.Order.Application.Features.CQRS.Handlers; 

public class GetAddressQueryHandler
{
    private readonly IRepository<Address> _repository;
    public GetAddressQueryHandler(IRepository<Address> repository)
    {
        _repository = repository;
    }
    public async Task<List<GetAddressQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetAddressQueryResult
        {
            AddressId = x.AddressId,
            City = x.City,
            Detail = x.Detail,
            District = x.District,
            UserId = x.UserId
        }).ToList();
    }
}
