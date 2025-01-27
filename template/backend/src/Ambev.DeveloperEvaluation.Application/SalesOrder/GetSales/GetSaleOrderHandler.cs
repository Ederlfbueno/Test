using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SalesOrder.GetSales
{
    /// <summary>
    /// Handles the request to retrieve a sale by its ID or sale number.
    /// </summary>
    public class GetSaleOrderHandler : IRequestHandler<GetSaleOrderCommand, GetSaleOrderResult>
    {
        private readonly ISaleOrderRepository _saleRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSaleOrderHandler"/> class.
        /// </summary>
        /// <param name="saleRepository">The repository for accessing sale order data.</param>
        /// <param name="mapper">The AutoMapper instance for object mapping.</param>
        public GetSaleOrderHandler(ISaleOrderRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the request to retrieve a sale order based on SaleId or SaleNumber.
        /// </summary>
        /// <param name="request">The query containing the SaleId or SaleNumber.</param>
        /// <param name="cancellationToken">The cancellation token for the task.</param>
        /// <returns>A <see cref="GetSaleOrderResult"/> containing the details of the sale.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the sale is not found.</exception>
        public async Task<GetSaleOrderResult> Handle(GetSaleOrderCommand request, CancellationToken cancellationToken)
        {
            // Attempt to find the sale order by ID or SaleNumber
            var sale = await _saleRepository.GetByIdAsync(request.SaleId)
                        ?? await _saleRepository.GetBySaleNumberAsync(request.SaleNumber);

            if (sale == null)
                throw new KeyNotFoundException("Sale order not found");

            // Map the sale order entity to the result object
            return _mapper.Map<GetSaleOrderResult>(sale);
        }
    }
}
