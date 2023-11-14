using EBuyAPI_DTO.Product;
using FluentValidation;

namespace EBuy.API.Validators.Product
{
    public class CreateProductDTOValidator : AbstractValidator<CreateProductDTO>
    {
        public CreateProductDTOValidator()
        {
            RuleFor(p => p.Name).ValidateName();
            RuleFor(p => p.Description).ValidateDescription();
            RuleFor(p => p.Price).NotEmpty();
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.BusinessId).NotEmpty();
        }
    }
}
