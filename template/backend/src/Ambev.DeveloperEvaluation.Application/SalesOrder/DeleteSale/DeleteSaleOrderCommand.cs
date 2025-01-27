using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SalesOrder.DeleteSale
{
    /// <summary>
    /// Command to delete (cancel) a sale.
    /// </summary>
    public class DeleteSaleOrderCommand : IRequest<Unit>
    {
        public Guid SaleId { get; set; }
    }
}
