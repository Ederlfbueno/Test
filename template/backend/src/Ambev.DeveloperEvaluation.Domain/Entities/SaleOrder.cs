using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a sale order details and details about products. 
    /// This entity follows domain-driven design principles and includes business rules validation.
    /// </summary>
    public class SaleOrder : BaseEntity
    {
        /// <summary>
        /// Gets or sets the unique number of the sale.
        /// </summary>
        public string SalerOrderNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date on which the sale order was made
        /// </summary>
        public DateTime SaleOrderDate { get; set; }

        /// <summary>
        /// Gets or sets the customer who made the purchase.
        /// </summary>
        public string Customer { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the total value of the sale.
        /// </summary>
        public decimal TotalValue { get; set; }

        /// <summary>
        /// Gets or sets the branch on which the sale order was made.
        /// </summary>
        public string Branch { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the list of products associated with the sale order.
        /// </summary>
        public List<SaleOrderProduct> Products { get; set; } = [];

        /// <summary>
        /// Gets or sets whether the sale order is canceled or active.
        /// </summary>
        public bool Canceled { get; set; }

        /// <summary>
        /// Gets the date and time when the sale order was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets the date and time of the last update to the sale order information.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Initializes a new instance of the sale order class whitout products.
        /// </summary>
        public SaleOrder()
        {
            CreatedAt = DateTime.UtcNow;
            Canceled = false;
        }

        /// <summary>
        /// Initializes a new instance of the sale order class whit products.
        /// </summary>
        /// <param name="products">The list of products to add in the sale order.</param>
        public SaleOrder(IEnumerable<SaleOrderProduct> products)
        {
            foreach (var product in products)
            {
                AddItem(product);
            }

            CreatedAt = DateTime.UtcNow;
            Canceled = false;
        }

        /// <summary>
        /// Cancels the current sale, marking it as cancelled and setting the update timestamp.
        /// </summary>
        public void CancelSale()
        {
            Canceled = true;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Adds an item to the sale, applying business rules for discounts and quantity validation.
        /// </summary>
        /// <param name="product">The sale item to add.</param>
        public void AddItem(SaleOrderProduct product)
        {
            if (product.Quantity > 20)
                throw new InvalidOperationException("You cannot sell more than 20 units of the same product.");

            if (product.Quantity >= 10)
                product.Discount = 0.20m;
            else if (product.Quantity >= 4)
                product.Discount = 0.10m;
            else
                product.Discount = 0m;

            product.TotalValue = product.Quantity * product.UnitPrice * (1 - product.Discount);
            Products.Add(product);
            UpdateTotalAmount();
        }

        /// <summary>
        /// Updates the total sale value based on products total value.
        /// </summary>
        public void UpdateTotalAmount()
        {
            TotalValue = Products.Sum(i => i.TotalValue);
        }

        /// <summary>
        /// Update date and time of the sale order.
        /// </summary>
        public void UpdatedSaleOrder()
        {
            UpdatedAt = DateTime.Now;
        }

        public ValidationResultDetail Validate()
        {
            var validator = new SaleOrderValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

    }

}
