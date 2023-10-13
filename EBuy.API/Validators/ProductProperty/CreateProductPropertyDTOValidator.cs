using EBuy.API.DTO.ProductProperty;
using FluentValidation;

namespace EBuy.API.Validators.ProductProperty
{
    public class CreateProductPropertyDTOValidator : AbstractValidator<CreateProductPropertyDTO>
    {
        public CreateProductPropertyDTOValidator()
        {
            RuleFor(p => p.Name).ValidateName();
            RuleFor(p => p.ProductPropertyTypeId).NotEmpty();
        }
    }
}
