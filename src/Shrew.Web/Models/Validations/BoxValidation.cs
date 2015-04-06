using FluentValidation;
using Shrew.Web.Models.Domain;

namespace Shrew.Web.Models.Validations
{
    public class BoxValidation : AbstractValidator<Box>
    {
        public BoxValidation()
        {
            RuleFor(box => box.Name)
                .NotEmpty();
        }

        private bool BePublished()
        {
            return true;
        }
    }


}