using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartProfile : Profile
    {
        public CreateCartProfile()
        {
            CreateMap<CreateCartCommand, Cart>();
            CreateMap<Cart, CreateCartResult>();

            CreateMap<CreateCartItemCommand, CartItem>();
            CreateMap<CartItem, CreateCartItemResult>();
        }
    }
}
