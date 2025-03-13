using FluentResults;
using MediatR;

namespace PrecoCombustivel.Features.Combustivel.Commands;

public record CreateCombustivelCommand(string tipo, string localizacao, decimal preco) : IRequest<Result<Guid>>;

public class CreateCombustivelCommandHandler : IRequestHandler<CreateCombustivelCommand, Result<Guid>>
{
    private readonly CombustivelRepository _repository;
    public CreateCombustivelCommandHandler(CombustivelRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Guid>> Handle(CreateCombustivelCommand request, CancellationToken cancellationToken)
    {
        var combustivel = new Domain.Entities.Combustivel(request.tipo, request.localizacao, request.preco);
        await _repository.AddAsync(combustivel);

        return Result.Ok(combustivel.Id);
    }
}

