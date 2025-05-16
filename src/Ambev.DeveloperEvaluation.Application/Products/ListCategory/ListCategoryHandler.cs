using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListCategory;

/// <summary>
/// Handler for processing ListCategoryCommand requests
/// </summary>
public class ListCategoryHandler : IRequestHandler<ListCategoryCommand, PaginatedList<ListCategoryResult>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ListCategoryHandler
    /// </summary>
    /// <param name="productRepository">The product repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for ListCategoryCommand</param>
    public ListCategoryHandler(
        IProductRepository productRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ListCategoryCommand request
    /// </summary>
    /// <param name="request">The ListCategory command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product details if found</returns>
    public async Task<PaginatedList<ListCategoryResult>> Handle(ListCategoryCommand request, CancellationToken cancellationToken)
    {
        var validator = new ListCategoryValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var carts = await _productRepository.GetByCategoryAsync(request.Category, request.Page, request.Size, request.Order, cancellationToken);

        var cartResult = _mapper.Map<PaginatedResponse<ListCategoryResult>>(carts);

        var result = new PaginatedList<ListCategoryResult>(
            cartResult,
            carts.TotalCount,
            carts.CurrentPage,
            carts.PageSize
        );

        return result;
    }
}
