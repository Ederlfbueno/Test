using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    /// <summary>
    /// Interface for managing sales orders in the repository.
    /// </summary>
    public interface ISaleOrderRepository
    {
        /// <summary>
        /// Create a sale order
        /// </summary>
        /// <param name="sale">The sale order to be created</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Returns the sale order created</returns>
        Task<SaleOrder> CreateAsync(SaleOrder sale, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a sale order by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the sale order</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale order if found, null otherwise</returns>
        Task<SaleOrder?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a sale order by their identifier
        /// </summary>
        /// <param name="saleNumber">The identifier of the sale order</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale order if found, null otherwise</returns>
        Task<SaleOrder?> GetBySaleNumberAsync(string saleNumber, CancellationToken cancellationToken = default);

        /// <summary>
        /// Uptade a sale order
        /// </summary>
        /// <param name="sale">The sale order to be updatedr</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale order updated</returns>
        Task<SaleOrder> UpdateAsync(SaleOrder sale, CancellationToken cancellationToken = default);
    }
}
