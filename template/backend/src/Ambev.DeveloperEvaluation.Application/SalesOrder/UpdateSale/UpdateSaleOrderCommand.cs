using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SalesOrder.UpdateSale
{
    /// <summary>
    /// Command to update an existing sale order.
    /// </summary>
    public class UpdateSaleOrderCommand : IRequest<Unit>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale order to update.
        /// </summary>
        public Guid SaleId { get; set; }

        /// <summary>
        /// Gets or sets the updated customer.
        /// </summary>
        public string Customer { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the updated branch where the sale order occurred.
        /// </summary>
        public string Branch { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the updated list of products in the sale order.
        /// </summary>
        public List<UpdateSaleOrderProductCommand> Products { get; set; } = new();
    }

    /// <summary>
    /// Represents an individual sale item within the UpdateSaleOrderCommand.
    /// </summary>
    public class UpdateSaleOrderProductCommand
    {
        /// <summary>
        /// Gets or sets the product name of the sale item.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the quantity of the sale item.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the sale item.
        /// </summary>
        public decimal UnitPrice { get; set; }
    }
}
