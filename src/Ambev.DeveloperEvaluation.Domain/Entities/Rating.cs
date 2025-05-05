using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Rating : BaseEntity
    {

        /// <summary>
        /// Gets the rating's rate number.
        /// </summary>
        public decimal Rate {  get; set; }

        /// <summary>
        /// Gets the rating's count integer.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets the rating's productId Guid.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets the rating's product reference.
        /// </summary>
        public Product Product { get; set; }
    }
}
