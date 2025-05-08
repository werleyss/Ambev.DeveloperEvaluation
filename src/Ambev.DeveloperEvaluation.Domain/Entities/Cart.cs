using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a shopping cart containing items selected by a user, including the total value and associated user.
    /// </summary>
    public class Cart : BaseEntity
    {
        /// <summary>
        /// Gets or sets the identifier of the user who owns the cart.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the date when the cart was created or last updated.
        /// </summary>
        public DateTime Date { get; set; }

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
        }
    }
}
