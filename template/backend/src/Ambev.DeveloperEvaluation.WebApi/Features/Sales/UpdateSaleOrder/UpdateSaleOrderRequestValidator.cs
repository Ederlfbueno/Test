using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleOrderRequestValidator : AbstractValidator<UpdateSaleOrderRequest>
    {
        public UpdateSaleOrderRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Customer).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Branch).NotEmpty();

            RuleForEach(x => x.Items).ChildRules(item =>
            {
                item.RuleFor(i => i.ProductName).NotEmpty();
                item.RuleFor(i => i.Quantity).InclusiveBetween(1, 20);
                item.RuleFor(i => i.UnitPrice).GreaterThan(0);
            });
        }
    }
}
