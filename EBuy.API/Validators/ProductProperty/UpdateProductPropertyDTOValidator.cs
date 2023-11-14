using EBuyAPI_DTO.ProductProperty;
using FluentValidation;

namespace EBuy.API.Validators.ProductProperty
{
    public class UpdateProductPropertyDTOValidator : AbstractValidator<UpdateProductPropertyDTO>
    {
        public UpdateProductPropertyDTOValidator()
        {
            RuleFor(p => p.Name).ValidateName();
            RuleFor(p => p.ProductPropertyTypeId).NotEmpty();
        }
    }
}
