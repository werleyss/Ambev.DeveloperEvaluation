using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(product => product.Title)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Title must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Title cannot be longer than 50 characters.");
                
        RuleFor(product => product.Price)
            .NotEmpty()
            .GreaterThanOrEqualTo(0).WithMessage("Price must be greater than zero.");

        RuleFor(product => product.Description)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Description must be at least 3 characters long.")
            .MaximumLength(2000).WithMessage("Description cannot be longer than 2000 characters.");

        RuleFor(product => product.Category)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Category must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Category cannot be longer than 50 characters.");

        RuleFor(product => product.Image)
            .MaximumLength(2000).WithMessage("Image cannot be longer than 2000 characters.");
    }
}
