namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSaleOrder
{
    /// <summary>
    /// Response containing the details of a sale.
    /// </summary>
    public class GetSaleOrderResponse
    {
        public Guid Id { get; set; }
        public string SaleOrderNumber { get; set; } = string.Empty;
        public string Customer { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public decimal TotalValue { get; set; }
        public List<GetSaleOrderProductResponse> Products { get; set; } = [];
    }

    public class GetSaleOrderProductResponse
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalValue { get; set; }
    }
}
