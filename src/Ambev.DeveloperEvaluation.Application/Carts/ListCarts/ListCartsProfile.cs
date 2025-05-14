using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

namespace Ambev.DeveloperEvaluation.Application.Carts.ListCarts;

/// <summary>
/// Profile for mapping between Cart entity and ListCartsResponse
/// </summary>
public class ListCartsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListCarts operation
    /// </summary>
    public ListCartsProfile()
    {
        CreateMap<Cart, ListCartsResult>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

        CreateMap<CartItem, ListCartItemResult>();
    }
}
