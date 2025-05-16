using Ambev.DeveloperEvaluation.Application.Carts.ListCarts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.ListCarts;

/// <summary>
/// Profile for mapping ListCarts feature requests to commands
/// </summary>
public class ListCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListCarts feature
    /// </summary>
    public ListCartsProfile()
    {
        CreateMap<ListCartsRequest, ListCartsCommand>();

        CreateMap<ListCartsResult, ListCartsResponse>();

        CreateMap<ListCartItemResult, ListCartItemResponse>();
    }
}
