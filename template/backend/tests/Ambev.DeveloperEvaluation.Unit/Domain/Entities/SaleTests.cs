using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    /// <summary>
    /// Tests for the Sale entity.
    /// </summary>
    public class SaleTests
    {
        [Fact(DisplayName = "Given sale with valid items When calculating total Then returns correct total")]
        public void CalculateTotal_ValidItems_ReturnsCorrectTotal()
        {
            // Arrange
            var sale = new SaleOrder
            {
                Products =
                [
                    new() { Quantity = 5, UnitPrice = 10.0m, TotalValue = 5 * 10.0m }, // Total = 50
                    new() { Quantity = 3, UnitPrice = 20.0m, TotalValue = 3 * 20.0m }  // Total = 60
                ]
            };

            // Act
            sale.UpdateTotalAmount();

            // Assert
            sale.TotalValue.Should().Be(110.0m);
        }

        [Fact(DisplayName = "Given sale with no items When calculating total Then total is zero")]
        public void CalculateTotal_NoItems_ReturnsZero()
        {
            // Arrange
            var sale = new SaleOrder { Products = [] };

            // Act
            sale.UpdateTotalAmount();

            // Assert
            sale.TotalValue.Should().Be(0.0m);
        }
    }
}
