using EBuy.Data.Constants;
using FluentValidation;

namespace EBuy.API.Validators
{
    public static class CommonValidationRules
    {
        //TODO: These messages require localization (by language)
        public static IRuleBuilderOptions<T, string> ValidateName<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(ConfigurationConstants.NameLength).WithMessage($"Name length must not exceed {ConfigurationConstants.NameLength}.");
        }

        public static IRuleBuilderOptions<T, string> ValidateFirstName<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("First name cannot be empty.")
                .MaximumLength(ConfigurationConstants.FirstNameLength).WithMessage($"First name length must not exceed {ConfigurationConstants.FirstNameLength}.");
        }

        public static IRuleBuilderOptions<T, string> ValidateLastName<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("Last name cannot be empty.")
                .MaximumLength(ConfigurationConstants.LastNameLength).WithMessage($"Last name length must not exceed {ConfigurationConstants.LastNameLength}.");
        }

        public static IRuleBuilderOptions<T, string> ValidateDescription<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("Description cannot be empty.")
                .MaximumLength(ConfigurationConstants.DescriptionLength).WithMessage($"Description length must not exceed {ConfigurationConstants.DescriptionLength}.");
        }

        public static IRuleBuilderOptions<T, string> ValidateEmail<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("Email address cannot be empty.")
                .EmailAddress().WithMessage("Please provide a valid email address.");
        }

        //TODO: Create constants for password's min and max lengths
        public static IRuleBuilderOptions<T, string> ValidatePassword<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("Password cannot be empty.")
                .MinimumLength(8).WithMessage("Password length must be at least 8.")
                .MaximumLength(50).WithMessage("Password length must not exceed 50.")
                .Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Password must contain at least one number.");
        }

        //TODO: Phone Regex requires localized regex (by country) currently it's for Turkish phones
        public static IRuleBuilderOptions<T, string> ValidatePhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("Password cannot be empty.")
                .Matches(@"[+]905[0-9]{9}").WithMessage("Please provide a valid phone number.");
        }

        public static IRuleBuilderOptions<T, string> ValidateAddress<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("Address cannot be empty.");

        }
    }
}
