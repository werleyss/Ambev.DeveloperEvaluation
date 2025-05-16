using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Application.Carts.ListCarts;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct;

/// <summary>
/// Handler for processing ListProductCommand requests
/// </summary>
public class ListProductsHandler : IRequestHandler<ListProductsCommand, PaginatedList<ListProductsResult>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ListProductHandler
    /// </summary>
    /// <param name="productRepository">The product repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for ListProductCommand</param>
    public ListProductsHandler(
        IProductRepository productRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ListProductCommand request
    /// </summary>
    /// <param name="request">The ListProduct command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product details if found</returns>
    public async Task<PaginatedList<ListProductsResult>> Handle(ListProductsCommand request, CancellationToken cancellationToken)
    {
        var validator = new ListProductsValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var carts = await _productRepository.GetAllAsync(request.Page, request.Size, request.Order, cancellationToken);

        var cartResult = _mapper.Map<PaginatedResponse<ListProductsResult>>(carts);

        var result = new PaginatedList<ListProductsResult>(
            cartResult,
            carts.TotalCount,
            carts.CurrentPage,
            carts.PageSize
        );

        return result;
    }
}
