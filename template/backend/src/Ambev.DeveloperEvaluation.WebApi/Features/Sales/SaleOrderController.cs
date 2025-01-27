using Ambev.DeveloperEvaluation.Application.SalesOrder.CreateSaleOrder;
using Ambev.DeveloperEvaluation.Application.SalesOrder.DeleteSale;
using Ambev.DeveloperEvaluation.Application.SalesOrder.GetSales;
using Ambev.DeveloperEvaluation.Application.SalesOrder.UpdateSale;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSaleOrder;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSaleOrder;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSaleOrder;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales
{
    /// <summary>
    /// Controller for managing sales operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SaleOrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of <see cref="SaleOrderController"/>.
        /// </summary>
        /// <param name="mediator">The mediator instance for sending commands and queries.</param>
        /// <param name="mapper">The AutoMapper instance for mapping objects.</param>
        public SaleOrderController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new sale order.
        /// </summary>
        /// <param name="request">The request containing sale order details.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The details of the created sale order.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleOrderResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSaleOrder([FromBody] CreateSaleOrderRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleOrderRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateSaleOrderCommand>(request);
            var result = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateSaleOrderResponse>
            {
                Success = true,
                Message = "Sale order successfully created",
                Data = _mapper.Map<CreateSaleOrderResponse>(result)
            });
        }

        /// <summary>
        /// Retrieves a sale order by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the sale order.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The details of the sale order.</returns>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetSaleOrderResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSaleOrder([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new GetSaleOrderRequest { Id = id };
            var validator = new GetSaleOrderRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<GetSaleOrderCommand>(request);
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<GetSaleOrderResponse>
            {
                Success = true,
                Message = "Sale retrieved successfully",
                Data = _mapper.Map<GetSaleOrderResponse>(result)
            });
        }

        /// <summary>
        /// Updates an existing sale.
        /// </summary>
        /// <param name="id">The unique identifier of the sale to update.</param>
        /// <param name="request">The request containing updated sale details.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>204 No Content if the update is successful.</returns>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateSale([FromRoute] Guid id, [FromBody] UpdateSaleOrderRequest request, CancellationToken cancellationToken)
        {
            request.Id = id;

            var validator = new UpdateSaleOrderRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<UpdateSaleOrderCommand>(request);
            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// Deletes (logical delete - cancels) an existing sale order.
        /// </summary>
        /// <param name="id">The unique identifier of the sale order to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>200 OK if the sale order is successfully deleted (canceled).</returns>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSale([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new DeleteSaleOrderRequest { Id = id };
            var validator = new DeleteSaleOrderRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<DeleteSaleOrderCommand>(request);
            await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Sale order successfully deleted "
            });
        }
    }
}
