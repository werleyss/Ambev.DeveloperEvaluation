using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    /// <summary>
    /// AutoMapper profile that defines mappings related to the cart creation process.
    /// </summary>
    public class CreateCartProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCartProfile"/> class
        /// and configures the object-to-object mappings.
        /// </summary>
        public CreateCartProfile()
        {
            // Maps request models to command models
            CreateMap<CreateCartItemRequest, CreateCartItemCommand>();
            CreateMap<CreateCartRequest, CreateCartCommand>();

            // Maps result models to response models
            CreateMap<CreateCartResult, CreateCartResponse>();
            CreateMap<CreateCartItemResult, CreateCartItemResponse>();
        }
    }

}
