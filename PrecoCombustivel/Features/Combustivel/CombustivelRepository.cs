using Microsoft.EntityFrameworkCore;
using PrecoCombustivel.Infrastructure.Context;

namespace PrecoCombustivel.Features.Combustivel;

public class CombustivelRepository
{
    private readonly CombustivelDbContext _dbContext;

    public CombustivelRepository(CombustivelDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Domain.Entities.Combustivel>> GetAllCombustiveissAsync()
    {
        return await _dbContext.Combustiveis.ToListAsync();
    }
    public async Task AddAsync(Domain.Entities.Combustivel combustivel)
    {
        await _dbContext.Combustiveis.AddAsync(combustivel);
        await _dbContext.SaveChangesAsync();
    }

}

