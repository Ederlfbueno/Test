namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSaleOrder
{
    /// <summary>
    /// Request to delete (cancel) a sale.
    /// </summary>
    public class DeleteSaleOrderRequest
    {
        public Guid Id { get; set; }
    }
}
