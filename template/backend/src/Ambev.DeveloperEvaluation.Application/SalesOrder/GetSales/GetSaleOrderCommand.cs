using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SalesOrder.GetSales
{
    /// <summary>
    /// Query to get a sale by its ID or sale order number.
    /// </summary>
    public class GetSaleOrderCommand : IRequest<GetSaleOrderResult>
    {
        public Guid SaleId { get; set; }
        public string SaleNumber { get; set; } = string.Empty;
    }
}
