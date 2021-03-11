using FluentValidation;
using standard_webapi.Data.DTOs;

namespace standard_webapi.Data.Validation
{
    public class ClientDTOValidation : AbstractValidator<ClientDTO>
    {
        public ClientDTOValidation()
        {
            RuleFor(c => c.Gender)
                .Must(SetGender)
                .WithMessage("Gender must be: Male, Female or Not Binary.");

            RuleForEach(c => c.Contacts)
                .ChildRules(opt => opt.RuleFor(x => x.Email)
                    .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                    .WithMessage("Invalid email format."));

            RuleForEach(c => c.Contacts)
                .ChildRules(opt => opt.RuleFor(x => x.Phone)
                    .Matches("[1-9][0-9][0-9]{9}")
                    .WithMessage("Invalid phone format."));
        }

        private bool SetGender(string input)
        {
            return input == "Male" || input == "Female" || input == "Not Binary";
        }
    }
}