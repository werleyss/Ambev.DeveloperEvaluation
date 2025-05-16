using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.ListCarts;

/// <summary>
/// Validator for ListCartsRequest
/// </summary>
public class ListCartsRequestValidator : AbstractValidator<ListCartsRequest>
{
    /// <summary>
    /// Initializes validation rules for ListCartsRequest
    /// </summary>
    public ListCartsRequestValidator()
    {
        RuleFor(x => x.Page)
             .GreaterThan(0).WithMessage("Page number must be greater than zero.");

        RuleFor(x => x.Size)
            .GreaterThan(0).WithMessage("Page size must be greater than zero.")
            .LessThanOrEqualTo(100).WithMessage("Page size cannot exceed 100.");
    }
}
