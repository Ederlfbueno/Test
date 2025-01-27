using Ambev.DeveloperEvaluation.Application.SalesOrder.CreateSaleOrder;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    /// <summary>
    /// Contains unit tests for the <see cref="CreateSaleOrderHandler"/> class.
    /// </summary>
    public class CreateSaleHandlerTests
    {
        private readonly ISaleOrderRepository _repository;
        private readonly CreateSaleOrderHandler _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSaleHandlerTests"/> class.
        /// Sets up the test dependencies and creates fake data generators.
        /// </summary>
        public CreateSaleHandlerTests()
        {
            _repository = Substitute.For<ISaleOrderRepository>();
            _handler = new CreateSaleOrderHandler(_repository);
        }

        /// <summary>
        /// Tests that a valid sale creation request is handled successfully.
        /// </summary>
        [Fact(DisplayName = "Given valid sale data When creating sale Then returns success response")]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Given
            var command = new CreateSaleOrderCommand
            {
                SaleOrderNumber = "S12345",
                Customer = "John Doe",
                Branch = "Branch A",
                Products =
                [
                    new() { Name = "Product A", Quantity = 5, UnitPrice = 10.0m }
                ]
            };

            SaleOrder capturedSale = null; 

            _ = _repository.CreateAsync(Arg.Do<SaleOrder>(s => capturedSale = s))
                .Returns(capturedSale);

            // When
            var response = await _handler.Handle(command, CancellationToken.None);

            // Then
            response.Should().NotBeNull();
            response.Id.Should().Be(capturedSale.Id); // Compara com o ID gerado no mock
            response.SaleOrderNumber.Should().Be(command.SaleOrderNumber);

            await _repository.Received(1).CreateAsync(Arg.Any<SaleOrder>());
        }
    }
}
