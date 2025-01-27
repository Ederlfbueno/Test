using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleOrderValidator : AbstractValidator<SaleOrder>
    {
        public SaleOrderValidator()
        {
            RuleFor(sale => sale.Branch)
                 .NotEmpty()
                 .MinimumLength(3).WithMessage("Branch must be at least 3 characters long.")
                 .MaximumLength(255).WithMessage("Branch cannot be longer than 50 characters.");

            RuleFor(sale => sale.Customer)
                 .NotEmpty()
                 .MinimumLength(3).WithMessage("Customer must be at least 3 characters long.")
                 .MaximumLength(255).WithMessage("Customer cannot be longer than 50 characters.");
        }
    }
}
