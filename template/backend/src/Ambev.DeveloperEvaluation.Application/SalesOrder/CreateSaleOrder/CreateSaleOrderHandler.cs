using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SalesOrder.CreateSaleOrder
{
    /// <summary>
    /// Handles the creation of a new sale order.
    /// </summary>
    public class CreateSaleOrderHandler : IRequestHandler<CreateSaleOrderCommand, CreateSaleOrderResult>
    {
        private readonly ISaleOrderRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSaleOrderHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository for accessing sale data.</param>
        public CreateSaleOrderHandler(ISaleOrderRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handles the creation of a new sale order.
        /// </summary>
        /// <param name="request">The command containing sale order details.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>returns the created sale order result.</returns>
        public async Task<CreateSaleOrderResult> Handle(CreateSaleOrderCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<SaleOrderProduct> products = request.Products.Select(item => new SaleOrderProduct
            {
                Name = item.Name,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice
            });

            // Map request to domain entity
            var sale = new SaleOrder(products)
            {
                SalerOrderNumber = request.SaleOrderNumber,
                Customer = request.Customer,
                Branch = request.Branch,
            };

            await _repository.CreateAsync(sale, cancellationToken);

            return new CreateSaleOrderResult
            {
                Id = sale.Id,
                SaleOrderNumber = sale.SalerOrderNumber,
                TotalValue = sale.TotalValue
            };
        }
    }
}
