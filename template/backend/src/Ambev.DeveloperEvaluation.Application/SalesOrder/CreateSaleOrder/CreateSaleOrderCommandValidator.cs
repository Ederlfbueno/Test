using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SalesOrder.CreateSaleOrder
{
    /// <summary>
    /// Validator for CreateSaleOrderCommand.
    /// </summary>
    public class CreateSaleOrderCommandValidator : AbstractValidator<CreateSaleOrderCommand>
    {
        public CreateSaleOrderCommandValidator()
        {
            RuleFor(x => x.SaleOrderNumber)
                .NotEmpty().WithMessage("Sale Order number is required.");

            RuleFor(x => x.SaleDate)
                .NotEmpty().WithMessage("Sale Order date is required.");

            RuleFor(x => x.Customer)
                .NotEmpty().WithMessage("Customer is required.")
                .MaximumLength(200).WithMessage("Customer cannot exceed 200 characters.");

            RuleFor(x => x.Branch)
                .NotEmpty().WithMessage("Branch is required.");

            RuleForEach(x => x.Products).SetValidator(new CreateSaleOrderProductCommandValidator());
        }
    }

    /// <summary>
    /// Validator for CreateSaleOrderProductCommand.
    /// </summary>
    public class CreateSaleOrderProductCommandValidator : AbstractValidator<CreateSaleOrderProductCommand>
    {
        public CreateSaleOrderProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.")
                .LessThanOrEqualTo(20).WithMessage("Cannot sell more than 20 identical items.");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("Unit price must be greater than zero.");
        }
    }
}
