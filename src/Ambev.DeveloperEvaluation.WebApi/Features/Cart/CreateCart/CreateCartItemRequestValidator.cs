using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.CreateCart
{
    public class CreateCartItemRequestValidator : AbstractValidator<CreateCartItemRequest>
    {
        public CreateCartItemRequestValidator()
        {
            RuleFor(ci => ci.ProductId)
                    .NotEmpty()
                    .WithMessage("Product Identifier is mandatory.");

            RuleFor(ci => ci.Quantity)
                .NotEmpty()
                .GreaterThanOrEqualTo(0).WithMessage("Quantity must be greater than zero")
                .LessThanOrEqualTo(20).WithMessage("The quantity must be greater than zero and less than or equal to twenty");

        }
    }
}
