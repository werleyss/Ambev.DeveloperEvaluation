using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProductCategories;

/// <summary>
/// Profile for mapping ListProductCategories feature requests to commands
/// </summary>
public class ListProductCategoriesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListProductCategories feature
    /// </summary>
    public ListProductCategoriesProfile()
    {
        CreateMap<ListProductCategoriesRequest, ListProductCategoriesCommand>();
        CreateMap<ListProductCategoriesResult, ListProductCategoriesResponse>();
    }
}
