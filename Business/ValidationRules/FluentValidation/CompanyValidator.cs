using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    internal class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Şirket adı boş olamaz!");
            RuleFor(p => p.Name).MinimumLength(5).WithMessage("Şirket adı beş karakterden az olamaz!");
            RuleFor(p => p.Address).NotEmpty().WithMessage("Şirket adres boş olamaz!");
        }
    }
}
 