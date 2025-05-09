using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartCommand : IRequest<CreateCartResult>
    {
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public List<CreateCartItemCommand> Products { get; set; }

        public CreateCartCommand()
        {
            Products = new List<CreateCartItemCommand>();
        }

        public CreateCartCommand(Guid useId, List<CreateCartItemCommand> products)
        {
            UserId = useId;
            Products = products; 
        }

        public ValidationResultDetail Validate()
        {
            var validator = new CreateCartCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
