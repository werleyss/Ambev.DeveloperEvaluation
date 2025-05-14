using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart
{
    public class UpdateCartItemValidator : AbstractValidator<UpdateCartItemCommand>
    {
        public UpdateCartItemValidator()
        {
            RuleFor(ci => ci.ProductId)
             .NotEmpty()
             .WithMessage("Product Identifier is mandatory.");

            RuleFor(ci => ci.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero")
                .LessThanOrEqualTo(20).WithMessage("The quantity must be greater than zero and less than or equal to twenty");

            RuleFor(ci => ci.UnitPrice)
                .GreaterThan(0M).WithMessage("Unit price must be greater than zero")
                .LessThanOrEqualTo(999999.99M).WithMessage("The unit price is invalid");

            RuleFor(ci => ci.Discount)
                .GreaterThanOrEqualTo(0M).WithMessage("The discount cannot be less than zero")
                .LessThan(100M).WithMessage("The discount cannot be greater than one hundred");
        }
    }
}
