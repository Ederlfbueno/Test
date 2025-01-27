using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleOrderProductValidator : AbstractValidator<SaleOrderProduct>
    {
        public SaleOrderProductValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty()
                .WithMessage("Product name is required");

            RuleFor(product => product.Quantity)
                .NotEmpty()
                .LessThanOrEqualTo(20)
                .WithMessage("You cannot sell more than 20 units of the same product.");
        }
    }
}
