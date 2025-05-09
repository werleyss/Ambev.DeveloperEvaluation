using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct;

/// <summary>
/// Profile for mapping between Product entity and ListProductResponse
/// </summary>
public class ListProductsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListProduct operation
    /// </summary>
    public ListProductsProfile()
    {
        CreateMap<Product, ListProductsResult>();
    }
}
