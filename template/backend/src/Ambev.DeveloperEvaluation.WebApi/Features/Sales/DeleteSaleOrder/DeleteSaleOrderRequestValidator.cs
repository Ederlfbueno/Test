using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSaleOrder
{
    public class DeleteSaleOrderRequestValidator : AbstractValidator<DeleteSaleOrderRequest>
    {
        public DeleteSaleOrderRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Sale order ID is required.");
        }
    }
}
