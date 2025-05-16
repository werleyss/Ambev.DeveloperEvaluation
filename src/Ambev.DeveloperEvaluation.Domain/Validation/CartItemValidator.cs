using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class CartItemValidator : AbstractValidator<CartItem>
{
    public CartItemValidator()
    {
        RuleFor(ci => ci.ProductId)
                .NotEmpty()
                .WithMessage("Product Identifier is mandatory.");

        RuleFor(ci => ci.Quantity)
            .NotEmpty()
            .GreaterThanOrEqualTo(0).WithMessage("Quantity must be greater than zero")
            .LessThanOrEqualTo(20).WithMessage("The quantity must be greater than zero and less than or equal to twenty");
        
        RuleFor(ci => ci.UnitPrice)
            .GreaterThanOrEqualTo(0M).WithMessage("Unit price must be greater than zero")
            .LessThanOrEqualTo(999999.99M).WithMessage("The unit price is invalid");

        RuleFor(ci => ci.Discount)
            .GreaterThanOrEqualTo(0M).WithMessage("The discount cannot be less than zero")
            .LessThanOrEqualTo(100M).WithMessage("The discount cannot be greater than one hundred");
    }
}
