using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of ISaleOrdeRepository using Entity Framework Core
    /// </summary>
    public class SaleOrderRepository : ISaleOrderRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of SaleOrderRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public SaleOrderRepository(DefaultContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Create a sale order
        /// </summary>
        /// <param name="sale">The sale order to be created</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Returns the sale order created</returns>
        public async Task<SaleOrder> CreateAsync(SaleOrder sale, CancellationToken cancellationToken = default)
        {
            await _context.SaleOrder.AddAsync(sale);
            await _context.SaveChangesAsync();
            return sale;
        }

        /// <summary>
        /// Retrieves a sale order by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the sale order</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale order if found, null otherwise</returns>
        public async Task<SaleOrder?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.SaleOrder
                .Include(s => s.Products)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        /// <summary>
        /// Retrieves a sale order by their identifier
        /// </summary>
        /// <param name="saleNumber">The identifier of the sale order</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale order if found, null otherwise</returns>
        public async Task<SaleOrder?> GetBySaleNumberAsync(string saleNumber, CancellationToken cancellationToken = default)
        {
            return await _context.SaleOrder
                .Include(s => s.Products)
                .FirstOrDefaultAsync(s => s.SalerOrderNumber == saleNumber);
        }

        /// <summary>
        /// Uptade a sale order
        /// </summary>
        /// <param name="sale">The sale order to be updatedr</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale order updated</returns>
        public async Task<SaleOrder> UpdateAsync(SaleOrder sale, CancellationToken cancellationToken = default)
        {
            _context.SaleOrder.Update(sale);
            await _context.SaveChangesAsync();
            return sale;
        }
    }
}
