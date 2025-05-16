using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.ListCarts;

/// <summary>
/// Validator for ListCartsCommand
/// </summary>
public class ListCartsValidator : AbstractValidator<ListCartsCommand>
{
    /// <summary>
    /// Initializes validation rules for ListCartsCommand
    /// </summary>
    public ListCartsValidator()
    {
        RuleFor(x => x.Page)
             .GreaterThan(0).WithMessage("Page number must be greater than zero.");

        RuleFor(x => x.Size)
            .GreaterThan(0).WithMessage("Page size must be greater than zero.")
            .LessThanOrEqualTo(100).WithMessage("Page size cannot exceed 100.");
    }
}
