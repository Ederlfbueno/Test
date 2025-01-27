using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SalesOrder.DeleteSale
{
    /// <summary>
    /// Handles the request to cancel a sale.
    /// </summary>
    public class DeleteSaleOrderHandler : IRequestHandler<DeleteSaleOrderCommand, Unit>
    {
        private readonly ISaleOrderRepository _saleRepository;

        public DeleteSaleOrderHandler(ISaleOrderRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<Unit> Handle(DeleteSaleOrderCommand request, CancellationToken cancellationToken)
        {
            var sale = await _saleRepository.GetByIdAsync(request.SaleId)
                ?? throw new KeyNotFoundException("Sale not found.");

            sale.Canceled = true;
            sale.UpdatedAt = DateTime.UtcNow;

            await _saleRepository.UpdateAsync(sale);

            return Unit.Value;
        }
    }
}
