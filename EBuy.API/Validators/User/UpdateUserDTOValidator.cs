using EBuyAPI_DTO.User;
using FluentValidation;

namespace EBuy.API.Validators.User
{
    public class UpdateUserDTOValidator : AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserDTOValidator()
        {
            // TODO:Add BusinessId Validation
            RuleFor(u => u.FirstName).ValidateFirstName();
            RuleFor(u => u.LastName).ValidateLastName();
            RuleFor(u => u.Email).ValidateEmail();
            RuleFor(u => u.PhoneNumber).ValidatePhoneNumber();
            RuleFor(u => u.Address).ValidateAddress();
        }
    }
}
