﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSaleOrder
{
    public class CreateSaleOrderRequestValidator : AbstractValidator<CreateSaleOrderRequest>
    {
        public CreateSaleOrderRequestValidator()
        {
            RuleFor(x => x.SaleNumber).NotEmpty().MaximumLength(50);
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
