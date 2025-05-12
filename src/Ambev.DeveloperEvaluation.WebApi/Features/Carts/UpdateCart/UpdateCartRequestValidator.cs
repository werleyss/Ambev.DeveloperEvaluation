using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
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
    /// - Title: Required, must be between 3 and 50 characters
    /// - Price: Required, Must be greater than zero
    /// - Description: Required, must be between 3 and 2000 characters
    /// - Category: Required, must be between 3 and 50 characters
    /// - Image: Required, must be maximum 2000 characters
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