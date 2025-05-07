using Ambev.DeveloperEvaluation.Domain.Common;

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
        /// Calculates and updates the total value of all items in the cart.
        /// </summary>
        public void CalculateTotalValue()
        {
            TotalValue = CartItems.Sum(i => i.CalculateValue());
        }

        /// <summary>
        /// Adds an item to the cart. If the item already exists, it updates its quantity and recalculates the total value.
        /// </summary>
        /// <param name="item">The cart item to add or update.</param>
        public void AddItem(CartItem item)
        {
            if (_cartItems.Any(i => i.ProductId == item.ProductId))
            {
                var itemExist = _cartItems.FirstOrDefault(i => i.ProductId == item.ProductId);

                itemExist.AddQuantity(item.Quantity);

                item = itemExist;

                _cartItems.Remove(itemExist);
            }

            _cartItems.Add(item);

            CalculateTotalValue();
        }
    }

}
