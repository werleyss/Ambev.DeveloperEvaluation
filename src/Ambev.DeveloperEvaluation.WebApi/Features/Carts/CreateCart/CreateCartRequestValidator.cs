using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
    {
        public CreateCartRequestValidator()
        {
            RuleFor(cart => cart.UserId)
                .NotEmpty().WithMessage("UserId is required.");

            RuleFor(cart => cart.Date)
                .NotEmpty().WithMessage("Cart date is required.");

            //RuleForEach(cart => cart.Products).SetValidator(new CreateCartItemRequestValidator());
        }
    }
}
