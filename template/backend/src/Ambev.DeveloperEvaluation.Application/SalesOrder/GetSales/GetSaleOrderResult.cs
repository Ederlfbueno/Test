namespace Ambev.DeveloperEvaluation.Application.SalesOrder.GetSales
{
    /// <summary>
    /// Result object returned when retrieving a sale.
    /// </summary>
    public class GetSaleOrderResult
    {
        public Guid SaleId { get; set; }

        /// <summary>
        /// Gets or sets the sale order number.
        /// </summary>
        public string SaleNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date of the sale order.
        /// </summary>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        public string Customer { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the branch where the sale order was made.
        /// </summary>
        public string Branch { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the list of sale products .
        /// </summary>
        public List<SaleOrderProductResult> Products { get; set; } = [];

        /// <summary>
        /// Gets or sets the total amount of the sale.
        /// </summary>
        public decimal TotalValue { get; set; }

        /// <summary>
        /// Indicates whether the sale has been cancelled.
        /// </summary>
        public bool Canceled { get; set; }
    }

    /// <summary>
    /// Represents an individual item in the sale.
    /// </summary>
    public class SaleOrderProductResult
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
}
