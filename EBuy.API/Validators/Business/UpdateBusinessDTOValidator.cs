using EBuyAPI_DTO.Business;
using FluentValidation;

namespace EBuy.API.Validators.Business
{
    public class UpdateBusinessDTOValidator : AbstractValidator<UpdateBusinessDTO>
    {
        public UpdateBusinessDTOValidator()
        {
            RuleFor(b => b.Name).ValidateName();
            RuleFor(b => b.Address).ValidateAddress();
            RuleFor(b => b.PhoneNumber).ValidatePhoneNumber();
        }
    }
}
