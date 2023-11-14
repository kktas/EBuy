using EBuyAPI_DTO.Business;
using FluentValidation;

namespace EBuy.API.Validators.Business
{
    public class CreateBusinessDTOValidator : AbstractValidator<CreateBusinessDTO>
    {
        public CreateBusinessDTOValidator()
        {
            RuleFor(b => b.Name).ValidateName();
            RuleFor(b => b.Address).ValidateAddress();
            RuleFor(b => b.PhoneNumber).ValidatePhoneNumber();
        }
    }
}
