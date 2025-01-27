namespace Ambev.DeveloperEvaluation.Application.SalesOrder.CreateSaleOrder
{
    /// <summary>
    /// Result of the CreateSaleOrderCommand execution.
    /// </summary>
    public class CreateSaleOrderResult
    {
        public Guid Id { get; set; }
        public string SaleOrderNumber { get; set; } = string.Empty;
        public decimal TotalValue { get; set; }
        public bool IsSuccessful { get; set; }
        public List<string> Errors { get; set; } = new();
    }
}
