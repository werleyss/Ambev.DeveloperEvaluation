using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

/// <summary>
/// Handler for processing UpdateCartCommand requests
/// </summary>
public class UpdateCartHandler : IRequestHandler<UpdateCartCommand, UpdateCartResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of UpdateCartHandler
    /// </summary>
    /// <param name="cartRepository">The cart repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for UpdateCartCommand</param>
    public UpdateCartHandler(ICartRepository cartRepository, IProductRepository productRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the UpdateCartCommand request
    /// </summary>
    /// <param name="command">The UpdateCart command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created cart details</returns>
    public async Task<UpdateCartResult> Handle(UpdateCartCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateCartValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingCart = await _cartRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingCart == null) throw new DomainException($"Cart with ID {command.Id} not found");

        foreach (var item in command.Products)
        {
            var product = await _productRepository.GetByIdAsync(item.ProductId);

            if (product == null) throw new DomainException($"Product with ID {item.ProductId} not found");

            existingCart.UpdateItem(new CartItem(item.ProductId, product.Title, item.Quantity, product.Price));
        }

        var createdCart = await _cartRepository.UpdateAsync(existingCart, cancellationToken);
        var result = _mapper.Map<UpdateCartResult>(createdCart);
        return result;
    }
}
