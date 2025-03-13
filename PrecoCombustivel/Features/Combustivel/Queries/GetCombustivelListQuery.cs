using FluentResults;
using MediatR;

namespace PrecoCombustivel.Features.Combustivel.Queries
{
    public record GetCombustivelListQuery : IRequest<Result<List<Domain.Entities.Combustivel>>>;

    public record GetCombustivelListQueryHandler : IRequestHandler<GetCombustivelListQuery, Result<List<Domain.Entities.Combustivel>>>
    {
        private readonly CombustivelRepository _repository;
        public GetCombustivelListQueryHandler(CombustivelRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<Domain.Entities.Combustivel>>> Handle(GetCombustivelListQuery request, CancellationToken cancellationToken)
        {
            var combustiveis = await _repository.GetAllCombustiveissAsync();
            return Result.Ok(combustiveis);
        }
    }
}
