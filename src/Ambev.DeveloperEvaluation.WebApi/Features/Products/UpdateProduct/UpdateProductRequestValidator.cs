using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

/// <summary>
/// Validator for UpdateProductRequest that defines validation rules for user creation.
/// </summary>
public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
    /// <summary>
    /// Initializes a new instance of the UpdateProductRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Title: Required, must be between 3 and 50 characters
    /// - Price: Required, Must be greater than zero
    /// - Description: Required, must be between 3 and 2000 characters
    /// - Category: Required, must be between 3 and 50 characters
    /// - Image: Required, must be maximum 2000 characters
    /// </remarks>
    public UpdateProductRequestValidator()
    {
        RuleFor(product => product.Id).NotEmpty().WithMessage("Product ID is required");
        RuleFor(product => product.Title).NotEmpty().Length(3, 50);
        RuleFor(product => product.Price).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(product => product.Description).NotEmpty().Length(3, 2000);
        RuleFor(product => product.Category).NotEmpty().Length(3, 50);
        RuleFor(product => product.Image).MaximumLength(2000);
    }
}