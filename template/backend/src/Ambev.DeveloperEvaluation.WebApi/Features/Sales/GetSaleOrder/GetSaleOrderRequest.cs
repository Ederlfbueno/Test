namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSaleOrder
{
    /// <summary>
    /// Request to retrieve a sale by its ID.
    /// </summary>
    public class GetSaleOrderRequest
    {
        public Guid Id { get; set; }
    }
}
