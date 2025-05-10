using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    public class CreateCartProfile : Profile
    {
        public CreateCartProfile()
        {
            CreateMap<CreateCartItemRequest, CreateCartItemCommand>();
            CreateMap<CreateCartRequest, CreateCartCommand>();

            CreateMap<CreateCartResult, CreateCartResponse>();
            CreateMap<CreateCartItemResult, CreateCartItemResponse>();
        }
    }
}
