﻿namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.ListCarts
{
    public class ListCartItemResponse
    {
        /// <summary>
        /// The unique identifier of the product.
        /// </summary>
        public Guid ProductId { get; set; }
        /// <summary>
        /// The quantity of the product in the cart.
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// The unit price of the product.
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// The discount applied to the product
        /// </summary>
        public decimal Discount { get; set; }
        /// <summary>
        /// The total price of the product item after applying quantity and discount.
        /// </summary>
        public decimal TotalPrice { get; private set; }
    }
}
