﻿namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartItemResult
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; private set; }
    }
}
