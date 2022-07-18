using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    internal class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p =>p.Name).NotEmpty().WithMessage("Kullanıcı adı boş olamaz!");
            RuleFor(p =>p.Name).MinimumLength(5).WithMessage("Kullanıcı adı en az 5 karakter olmalı!");
            RuleFor(p =>p.Email).NotEmpty().WithMessage("Mail boş olamaz!");
            RuleFor(p =>p.Email).EmailAddress().WithMessage("Geçerli bir email adresi yazın!");
        }
    }
}
