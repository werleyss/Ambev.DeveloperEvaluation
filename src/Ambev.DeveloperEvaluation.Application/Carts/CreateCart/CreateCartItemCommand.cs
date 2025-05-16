using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartItemCommand : IRequest<CreateCartItemResult>
    {
        public Guid ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }

        public CreateCartItemCommand()
        {
            
        }
        public CreateCartItemCommand(Guid productId,  string productTitle, int quantity, decimal unitPrice)
        {
            ProductId = productId;
            ProductTitle = productTitle;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public ValidationResultDetail Validate()
        {
            var validator = new CreateCartItemValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
