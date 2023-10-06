using AutoMapper;
using EBuy.API.DTO.User;
using EBuy.Data.Constants;
using FluentValidation;
using System;
using System.Net;
using System.Numerics;

namespace EBuy.API.Validators.User
{
    public class CreateUserDTOValidator : AbstractValidator<CreateUserDTO>
    {
        public CreateUserDTOValidator()
        {
            // TODO:Add BusinessId Validation
            RuleFor(u => u.FirstName).ValidateFirstName();
            RuleFor(u => u.LastName).ValidateLastName();
            RuleFor(u => u.Email).ValidateEmail();
            RuleFor(u => u.Password).ValidatePassword();
            RuleFor(u => u.PhoneNumber).ValidatePhoneNumber();
            RuleFor(u => u.Address).ValidateAddress();
        }
    }
}
