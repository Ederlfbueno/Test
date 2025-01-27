namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSaleOrder
{
    /// <summary>
    /// Response after successfully creating a sale.
    /// </summary>
    public class CreateSaleOrderResponse
    {
        public Guid Id { get; set; }
        public string SaleOrderNumber { get; set; } = string.Empty;
        public string Customer { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public decimal TotalValue { get; set; }
    }
}
