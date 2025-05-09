using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.CreateCart
{
    public class CreateCartProfile : Profile
    {
        public CreateCartProfile()
        {
            CreateMap<CreateCartRequest, CreateCartCommand>()
           .ConstructUsing(src => new CreateCartCommand());

            CreateMap<CreateCartItemRequest, CreateCartItemCommand>();

            CreateMap<CreateCartResult, CreateCartResponse>();
            CreateMap<CreateCartItemResult, CreateCartItemResponse>();
        }
    }
}
