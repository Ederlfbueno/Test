using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SalesOrder.CreateSaleOrder
{
    /// <summary>
    /// Command for creating a new sale order.
    /// </summary>
    /// <remarks>
    /// This command captures the required data for creating a sale order, 
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="CreateSaleOrderResult"/>.
    /// </remarks>
    public class CreateSaleOrderCommand : IRequest<CreateSaleOrderResult>
    {
        /// <summary>
        /// Gets or sets the sale order number.
        /// </summary>
        public string SaleOrderNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date of the sale order.
        /// </summary>
        public DateTime SaleDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the customer name for the sale order.
        /// </summary>
        public string Customer { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the branch where the sale order occurred.
        /// </summary>
        public string Branch { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the list of sale order products.
        /// </summary>
        public List<CreateSaleOrderProductCommand> Products { get; set; } = new();

        /// <summary>
        /// Performs validation for the CreateSaleOrderCommand.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed.
        /// - Errors: Collection of validation errors if any rules failed.
        /// </returns>
        public ValidationResultDetail Validate()
        {
            var validator = new CreateSaleOrderCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }

    /// <summary>
    /// Command for a sale order product within the sale order.
    /// </summary>
    public class CreateSaleOrderProductCommand
    {
        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the quantity of the product.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the product.
        /// </summary>
        public decimal UnitPrice { get; set; }
    }
}
