using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SalesOrder.UpdateSale
{
    /// <summary>
    /// Handles the request to update a sale.
    /// </summary>
    public class UpdateSaleOrderHandler : IRequestHandler<UpdateSaleOrderCommand, Unit>
    {
        private readonly ISaleOrderRepository _saleRepository;

        public UpdateSaleOrderHandler(ISaleOrderRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<Unit> Handle(UpdateSaleOrderCommand request, CancellationToken cancellationToken)
        {
            var sale = await _saleRepository.GetByIdAsync(request.SaleId)
                ?? throw new KeyNotFoundException("Sale not found.");

            sale.Customer = request.Customer;
            sale.Branch = request.Branch;

            sale.Products.Clear();
            foreach (var item in request.Products)
            {
                sale.Products.Add(new SaleOrderProduct
                {
                    Name = item.Name,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    TotalValue = item.Quantity * item.UnitPrice
                });
            }

            sale.TotalValue = sale.Products.Sum(i => i.TotalValue);
            sale.UpdatedAt = DateTime.UtcNow;

            await _saleRepository.UpdateAsync(sale);

            return Unit.Value;  
        }
    }
}
