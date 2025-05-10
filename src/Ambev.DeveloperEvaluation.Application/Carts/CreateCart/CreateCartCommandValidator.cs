using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
    {
        public CreateCartCommandValidator()
        {
            RuleFor(ci => ci.UserId)
             .NotEmpty()
             .WithMessage("Product Identifier is mandatory.");

            //RuleForEach(cart => cart.Products).SetValidator(new CreateCartItemCommandValidator());
        }
    }
}
