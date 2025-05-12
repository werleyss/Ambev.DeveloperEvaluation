using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartHandler : IRequestHandler<CreateCartCommand, CreateCartResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of CreateCartHandler
        /// </summary>
        /// <param name="cartRepository">The cart repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        /// <param name="validator">The validator for CreateCartCommand</param>
        public CreateCartHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the CreateCartCommand request
        /// </summary>
        /// <param name="command">The CreateCart command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created or updated cart details</returns>
        public async Task<CreateCartResult> Handle(CreateCartCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateCartValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingCart = await _cartRepository.GetOpenCartByUserIdAsync(command.UserId, cancellationToken);

            if (existingCart != null)
            {
                var cart = _mapper.Map<Cart>(command);

                foreach (var item in cart.CartItems)
                {
                    existingCart.AddItem(item);
                }

                await _cartRepository.UpdateAsync(existingCart, cancellationToken);

                var updatedResult = _mapper.Map<CreateCartResult>(existingCart);
                return updatedResult;
            }
            else
            {
                var cart = _mapper.Map<Cart>(command);

                await _cartRepository.CreateAsync(cart, cancellationToken);

                var createdResult = _mapper.Map<CreateCartResult>(cart);
                return createdResult;
            }
        }

    }
}
