using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

/// <summary>
/// Validator for UpdateCartItemRequest that defines validation rules for user creation.
/// </summary>
public class UpdateCartItemRequestValidator : AbstractValidator<UpdateCartItemRequest>
{
    /// <summary>
    /// Initializes a new instance of the UpdateCartItemRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - ProductId: Required, Unique identifier of the product
    /// - Quantity: Required, Must be greater than zero and Less or equal 20
    /// </remarks>
    public UpdateCartItemRequestValidator()
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