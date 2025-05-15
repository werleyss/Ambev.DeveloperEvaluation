using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

/// <summary>
/// Validator for UpdateCartRequest that defines validation rules for user creation.
/// </summary>
public class UpdateCartRequestValidator : AbstractValidator<UpdateCartRequest>
{
    /// <summary>
    /// Initializes a new instance of the UpdateCartRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - UserId: Required, Unique identifier of the user
    /// - Date: Required, Date the cart was created
    /// </remarks>
    public UpdateCartRequestValidator()
    {

        RuleFor(cart => cart.UserId)
            .NotEmpty().WithMessage("UserId is required.");

        RuleFor(cart => cart.Date)
            .NotEmpty().WithMessage("Cart date is required.");

        RuleForEach(cart => cart.Products).SetValidator(new UpdateCartItemRequestValidator());
    }
}