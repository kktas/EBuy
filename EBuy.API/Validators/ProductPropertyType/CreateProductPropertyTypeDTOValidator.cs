using EBuy.API.DTO.ProductPropertyType;
using FluentValidation;

namespace EBuy.API.Validators.ProductPropertyType
{
    public class CreateProductPropertyTypeDTOValidator : AbstractValidator<CreateProductPropertyTypeDTO>
    {
        public CreateProductPropertyTypeDTOValidator()
        {
            RuleFor(p => p.Name).ValidateName();
            RuleFor(p => p.CategoryId).NotEmpty();
        }
    }
}
