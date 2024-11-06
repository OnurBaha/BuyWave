using BuyWave.Order.Application.Features.Mediator.Commands.OrderingCommands;
using BuyWave.Order.Application.Interfaces;
using BuyWave.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyWave.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
{
    private readonly IRepository<Ordering> _repository;
    public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIdAsync(request.OrderingId);
        values.OrderDate = request.OrderDate;
        values.UserId = request.UserId;
        values.TotalPrice = request.TotalPrice;
        await _repository.UpdateAsync(values);
    }
}
