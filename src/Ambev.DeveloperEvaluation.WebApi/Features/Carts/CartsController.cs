﻿using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
using Ambev.DeveloperEvaluation.Application.Carts.ListCarts;
using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.ListCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of CartsController
        /// </summary>
        /// <param name="mediator">The mediator instance</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public CartsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new cart
        /// </summary>
        /// <param name="request">The cart creation request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created cart details</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateCartResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCart([FromBody] CreateCartRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateCartRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateCartCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateCartResponse>
            {
                Success = true,
                Message = "Cart created successfully",
                Data = _mapper.Map<CreateCartResponse>(response)
            });
        }

        /// <summary>
        /// Retrieves a cart by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the cart</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The cart details if found</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetCartResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCart([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new GetCartRequest { Id = id };
            var validator = new GetCartRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<GetCartCommand>(request.Id);
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(_mapper.Map<GetCartResponse>(response), "Cart retrieved successfully");
        }

        /// <summary>
        /// Deletes a cart by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the cart to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Success response if the cart was deleted</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCart([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new DeleteCartRequest { Id = id };
            var validator = new DeleteCartRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<DeleteCartCommand>(request.Id);
            await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Cart deleted successfully"
            });
        }

        /// <summary>
        /// Updates a cart by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the cart to update</param>
        /// <param name="request">The cart update request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated cart details</returns>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(ApiResponseWithData<UpdateCartResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCart(Guid id, [FromBody] UpdateCartRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCartRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<UpdateCartCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<UpdateCartResponse>
            {
                Success = true,
                Message = "Cart updated successfully",
                Data = _mapper.Map<UpdateCartResponse>(response)
            });
        }

        /// <summary>
        /// Retrieves a paginated list of carts.
        /// </summary>
        /// <param name="page">Page number (default 1).</param>
        /// <param name="size">Page size (default 10).</param>
        /// <param name="order">Ordering string, e.g., "id desc, userId asc".</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Paginated list of carts.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResponse<ListCartsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListCarts(
        [FromQuery(Name = "_page")] int page = 1,
        [FromQuery(Name = "_size")] int size = 10,
        [FromQuery(Name = "_order")] string? order = null,
        CancellationToken cancellationToken = default)
        {
            var request = new ListCartsRequest { Page = page, Size = size, Order = order };
            var validator = new ListCartsRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<ListCartsCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            var listResponse = _mapper.Map<List<ListCartsResponse>>(response);

            var result = new PaginatedResponse<ListCartsResponse>
            {
                Data = listResponse,
                TotalCount = response.TotalCount,
                CurrentPage = response.CurrentPage,
                TotalPages = response.TotalPages,
                Success = true,
            };

            return Ok(result);
        }
    }
}
