using Ambev.DeveloperEvaluation.Application.Products.ListCategories;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListCategories;

/// <summary>
/// Profile for mapping ListCategories feature requests to commands
/// </summary>
public class ListCategoriesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListCategories feature
    /// </summary>
    public ListCategoriesProfile()
    {
        CreateMap<ListCategoriesRequest, ListCategoriesCommand>();
    }
}
