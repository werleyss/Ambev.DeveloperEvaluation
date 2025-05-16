using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListCategories;

/// <summary>
/// Handler for processing ListCategoriesCommand requests
/// </summary>
public class ListCategoriesHandler : IRequestHandler<ListCategoriesCommand, List<string>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ListCategoriesHandler
    /// </summary>
    /// <param name="productRepository">The product repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for ListCategoriesCommand</param>
    public ListCategoriesHandler(
        IProductRepository productRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ListCategoriesCommand request
    /// </summary>
    /// <param name="request">The ListCategories command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Category list</returns>
    public async Task<List<string>> Handle(ListCategoriesCommand command, CancellationToken cancellationToken)
    {
        var categories = await _productRepository.GetAllCategoryAsync(cancellationToken);

        return categories;
    }
}
