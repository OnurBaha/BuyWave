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

public class RemoveOrderingCommandHandler : IRequestHandler<RemoveOrderingCommand>
{
    private readonly IRepository<Ordering> _repository;
    public RemoveOrderingCommandHandler(IRepository<Ordering> repository)
    {
        _repository = repository;
    }
    public async Task Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIdAsync(request.Id);
        await _repository.DeleteAsync(values);
    }
}
