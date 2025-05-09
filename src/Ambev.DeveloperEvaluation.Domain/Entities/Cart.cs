using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a shopping cart containing items selected by a user, including the total value and associated user.
    /// </summary>
    public class Cart : BaseEntity
    {
        /// <summary>
        /// The maximum number of units allowed per item in the cart.
        /// </summary>
        public static int ITEM_MAXIMUM_UNIT = 20;

        /// <summary>
        /// The minimum number of units required per item in the cart.
        /// </summary>
        public static int ITEM_MINIMUM_UNIT = 1;

        /// <summary>
        /// Gets or sets the identifier of the user who owns the cart.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the date when the cart was created or last updated.
        /// </summary>
        public DateTime Date { get; set; }

        public CartStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the total value of all items in the cart.
        /// </summary>
        public Decimal TotalValue { get; set; }

        private readonly List<CartItem> _cartItems;

        /// <summary>
        /// Gets the collection of items in the cart.
        /// </summary>
        public IReadOnlyCollection<CartItem> CartItems => _cartItems;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cart"/> class.
        /// </summary>
        public Cart()
        {
            _cartItems = new List<CartItem>();
        }

        /// <summary>
        /// Performs validation of the cart entity using CartValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        /// <remarks>
        /// <listheader>The validation includes checking:</listheader>
        /// <list type="bullet">UserId requirements</list>
        /// <list type="bullet">Date requirements</list>
        /// <list type="bullet">CartItems list valid</list>
        /// 
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            var validator = new CartValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        /// <summary>
        /// Calculates and updates the total value of all items in the cart.
        /// </summary>
        public void CalculateTotalValue()
        {
            TotalValue = CartItems.Sum(i => i.CalculateValue());
        }

        /// <summary>
        /// Checks if the cart already contains an item with the same ProductId.
        /// </summary>
        private bool ExistingCartItem(CartItem item)
        {
            return _cartItems.Any(i => i.ProductId == item.ProductId);
        }

        /// <summary>
        /// Validates whether the quantity of the specified cart item is within the allowed limits.
        /// Throws a <see cref="DomainException"/> if the quantity exceeds the maximum allowed units.
        /// </summary>
        /// <param name="item">The cart item to validate.</param>
        private void QuantityItemsAllowedValid(CartItem item)
        {
            var quantityItems = item.Quantity;

            if (ExistingCartItem(item))
            {
                var cartItemExisting = _cartItems.FirstOrDefault(i => i.ProductId == item.ProductId);

                quantityItems += cartItemExisting.Quantity;
            }

            if (quantityItems > ITEM_MAXIMUM_UNIT) throw new DomainException($"Maximum of {ITEM_MAXIMUM_UNIT} unit");
        }

        /// <summary>
        /// Validates that the specified cart item exists in the cart
        /// </summary>
        private void ValidExistingCartItem(CartItem item)
        {
            if (!ExistingCartItem(item)) throw new DomainException("The item does not exist in the cart.");
        }

        /// <summary>
        /// Adds an item to the cart. If the item already exists, it updates its quantity and recalculates the total value.
        /// </summary>
        /// <param name="item">The cart item to add or update.</param>
        public void AddItem(CartItem item)
        {
            QuantityItemsAllowedValid(item);

            if (ExistingCartItem(item))
            {
                var itemExist = _cartItems.FirstOrDefault(i => i.ProductId == item.ProductId);

                itemExist.AddQuantity(item.Quantity);

                item = itemExist;

                _cartItems.Remove(itemExist);
            }

            _cartItems.Add(item);

            CalculateTotalValue();
        }

        /// <summary>
        /// Update an item to the cart.
        /// </summary>
        /// <param name="item">The cart item to update.</param>
        public void UpdateItem(CartItem item)
        {
            ValidExistingCartItem(item);

            QuantityItemsAllowedValid(item);

            var cartItemExisting = _cartItems.FirstOrDefault(p => p.ProductId == item.ProductId);

            _cartItems.Remove(cartItemExisting);
            _cartItems.Add(item);

            CalculateTotalValue();
        }

        /// <summary>
        /// Remove an item to the cart.
        /// </summary>
        /// <param name="item">The cart item to remove.</param>
        public void RemoveItem(CartItem item)
        {
            ValidExistingCartItem(item);

            _cartItems.Remove(item);

            CalculateTotalValue();
        }
    }
}
