using Ambev.DeveloperEvaluation.Application.Products.ListCategory;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListCategory;

/// <summary>
/// Profile for mapping ListCategory feature requests to commands
/// </summary>
public class ListCategoryProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListCategory feature
    /// </summary>
    public ListCategoryProfile()
    {
        CreateMap<ListCategoryRequest, ListCategoryCommand>();
        CreateMap<ListCategoryResult, ListCategoryResponse>();
    }
}
