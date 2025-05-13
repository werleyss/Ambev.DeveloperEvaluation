using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartValidator : AbstractValidator<CreateCartCommand>
    {
        public CreateCartValidator()
        {
            RuleFor(ci => ci.UserId)
             .NotEmpty()
             .WithMessage("User Identifier is mandatory.");

            RuleForEach(cart => cart.Products).SetValidator(new CreateCartItemValidator());
        }
    }
}
