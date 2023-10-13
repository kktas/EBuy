using EBuy.API.DTO.ProductPropertyType;
using FluentValidation;

namespace EBuy.API.Validators.ProductPropertyType
{
    public class UpdateProductPropertyTypeDTOValidator : AbstractValidator<UpdateProductPropertyTypeDTO>
    {
        public UpdateProductPropertyTypeDTOValidator()
        {
            RuleFor(p => p.Name).ValidateName();
            RuleFor(p => p.CategoryId).NotEmpty();
        }
    }
}
