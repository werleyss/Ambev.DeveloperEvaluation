using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class CartItem : BaseEntity
    {
        /// <summary>
        /// Gets the unique identifier of the product associated with the cart item.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets the title of the product.
        /// </summary>
        public string ProductTitle { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product in the cart.
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// Gets the unit price of the product.
        /// </summary>
        public decimal UnitPrice { get; private set; }

        /// <summary>
        /// Gets the discount applied to the cart item based on the quantity of the product.
        /// </summary>
        public decimal Discount { get; private set; }

        /// <summary>
        /// Gets the total price for the cart item after applying the discount.
        /// </summary>
        public decimal TotalPrice { get; private set; }

        /// <summary>
        /// Gets the unique identifier of the cart associated with the cart item.
        /// </summary>
        public Guid CartId { get; set; }

        /// <summary>
        /// Gets the cart associated with the cart item
        /// </summary>
        public Cart Cart { get; set; }

        public CartItem(Guid productId, string productTitle, int quantity, decimal unitPrice)
        {
            ProductId = productId;
            ProductTitle = productTitle;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        /// <summary>
        /// Performs validation of the cart item entity using CartItemValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        /// <remarks>
        /// <listheader>The validation includes checking:</listheader>
        /// <list type="bullet">ProductId requirements</list>
        /// <list type="bullet">Quantity greater than zero</list>
        /// <list type="bullet">UnitPrice greater than zero</list>
        /// <list type="bullet">Discount less than one hundred and greater than or equal to zero</list>
        /// 
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            var validator = new CartItemValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        /// <summary>
        /// Calculates the total price of the cart item based on its quantity and unit price
        /// </summary>
        /// <returns>The total price after discount.</returns>
        public decimal CalculateValue()
        {
            ValidateQuantity();

            TotalPrice = Quantity * UnitPrice;

            if (Quantity >= 10 && Quantity < 20)
            {
                Discount = 20M;
            }
            else if (Quantity > 4)
            {
                Discount = 10M;
            }
            else
            {
                Discount = 0M;
            }

            decimal totalDiscount = TotalPrice * (Discount / 100);

            TotalPrice -= totalDiscount;

            return TotalPrice;
        }

        /// <summary>
        /// Adds the specified quantity to the current item quantity and validates
        /// that the total quantity does not exceed the allowed maximum.
        /// </summary>
        /// <param name="quantity">The quantity to add.</param>
        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
            ValidateQuantity();
        }

        /// <summary>
        /// Validates that the current quantity does not exceed 20 identical items.
        /// </summary>
        private void ValidateQuantity()
        {
            if (Quantity > Cart.ITEM_MAXIMUM_UNIT)
                throw new DomainException("It is not allowed to purchase more than 20 identical items.");
        }
    }
}
