using EBuy.API.DTO.Category;
using FluentValidation;

namespace EBuy.API.Validators.Category
{
    public class UpdateCategoryDTOValidator : AbstractValidator<UpdateCategoryDTO>
    {
        public UpdateCategoryDTOValidator()
        {
            RuleFor(u => u.Name).ValidateFirstName();
        }
    }
}
