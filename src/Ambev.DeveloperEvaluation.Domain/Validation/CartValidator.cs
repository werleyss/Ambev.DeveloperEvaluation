using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class CartValidator : AbstractValidator<Cart>
{
    public CartValidator()
    {
        RuleFor(cart => cart.UserId)
            .NotEmpty().WithMessage("UserId is required.");
        
        RuleFor(cart => cart.Date)
            .NotEmpty().WithMessage("Cart date is required.");

        RuleForEach(cart => cart.Products).SetValidator(new CartItemValidator());
    }
}
