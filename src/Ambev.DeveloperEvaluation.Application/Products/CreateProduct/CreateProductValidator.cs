using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductCommand that defines validation rules for product creation command.
/// </summary>
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Title: Required, must be between 3 and 50 characters
    /// - Price: Required, Must be greater than zero
    /// - Description: Required, must be between 3 and 2000 characters
    /// - Category: Required, must be between 3 and 50 characters
    /// - Image: Required, must be maximum 2000 characters
    /// </remarks>
    public CreateProductCommandValidator()
    {
        RuleFor(product => product.Title).NotEmpty().Length(3, 50);
        RuleFor(product => product.Price).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(product => product.Description).NotEmpty().Length(3, 2000);
        RuleFor(product => product.Category).NotEmpty().Length(3, 50);
        RuleFor(product => product.Image).MaximumLength(2000);
    }
}