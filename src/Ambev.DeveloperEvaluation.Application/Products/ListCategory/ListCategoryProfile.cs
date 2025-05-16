using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.ListCategory;

/// <summary>
/// Profile for mapping between Product entity and ListCategoryResponse
/// </summary>
public class ListCategoryProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListCategory operation
    /// </summary>
    public ListCategoryProfile()
    {
        CreateMap<Product, ListCategoryResult>();
    }
}
