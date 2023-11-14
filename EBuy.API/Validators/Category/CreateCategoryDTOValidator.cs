using EBuyAPI_DTO.Category;
using FluentValidation;

namespace EBuy.API.Validators.Category
{
    public class CreateCategoryDTOValidator : AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryDTOValidator()
        {
            RuleFor(u => u.Name).ValidateFirstName();
        }
    }
}
