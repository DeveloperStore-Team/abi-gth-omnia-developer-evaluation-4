using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IVendaRepository using Entity Framework Core
/// </summary>
public class VendaRepository : IVendaRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of VendaRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public VendaRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new sale in the database
    /// </summary>
    /// <param name="venda">The sale to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale</returns>
    public async Task<Venda> AddAsync(Venda venda, CancellationToken cancellationToken = default)
    {
        await _context.Vendas.AddAsync(venda, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return venda;
    }

    /// <summary>
    /// Retrieves a sale by its unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale if found, null otherwise</returns>
    public async Task<Venda?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Vendas
            .Include(v => v.Itens)
            .FirstOrDefaultAsync(v => v.Id == id, cancellationToken);
    }

    /// <summary>
    /// Updates an existing sale in the database
    /// </summary>
    /// <param name="venda">The sale to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated sale</returns>
    public async Task UpdateAsync(Venda venda, CancellationToken cancellationToken = default)
    {
        _context.Vendas.Update(venda);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Deletes a sale from the database
    /// </summary>
    /// <param name="id">The unique identifier of the sale to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the sale was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var venda = await GetByIdAsync(id, cancellationToken);
        if (venda == null)
            return false;

        _context.Vendas.Remove(venda);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// Retrieves all sales from the database
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A list of sales</returns>
    public async Task<List<Venda>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Vendas
            .Include(v => v.Itens)
            .ToListAsync(cancellationToken);
    }
}
