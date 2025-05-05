using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Product : BaseEntity
    {

        /// <summary>
        /// Gets the product's string number.
        /// Must not be null or empty.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product's price number.
        /// Must be greater than zero
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets the product's description string.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product's category string.
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product's image string.
        /// </summary>
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product's ratingid guid.
        /// </summary>
        public Guid RatingId { get; set; }

        /// <summary>
        /// Gets the product's rating reference.
        /// </summary>
        public Rating Rating { get; set; }

        /// <summary>
        /// Gets the date and time when the product was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets the date and time of the last update to the product's information.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Performs validation of the product entity using the ProductValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        /// <remarks>
        /// <listheader>The validation includes checking:</listheader>
        /// <list type="bullet">Title length</list>
        /// <list type="bullet">Price greater than zero</list>
        /// <list type="bullet">Description length</list>
        /// <list type="bullet">Category length</list>
        /// <list type="bullet">Image length</list>
        /// 
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            var validator = new ProductValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
