using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;

/// <summary>
/// Profile for mapping between Application and API UpdateCart responses
/// </summary>
public class UpdateCartProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateCart feature
    /// </summary>
    public UpdateCartProfile()
    {
        CreateMap<UpdateCartRequest, UpdateCartCommand>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
        CreateMap<UpdateCartResult, UpdateCartResponse>();

        CreateMap<UpdateCartItemRequest, UpdateCartItemCommand>();
        CreateMap<UpdateCartItemResult, UpdateCartItemResponse>();
    }
}
