using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSaleOrder
{
    public class GetSaleOrderRequestValidator : AbstractValidator<GetSaleOrderRequest>
    {
        public GetSaleOrderRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Sale Order ID is required.");
        }
    }
}
