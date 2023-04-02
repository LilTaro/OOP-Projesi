using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(X => X.CustomerCity).NotEmpty().WithMessage("Şehir Boş Olamaz");
            RuleFor(X => X.CustomerName).NotEmpty().WithMessage("İsim Boş Olamaz");
            RuleFor(X => X.CustomerCity).MinimumLength(3).WithMessage("Şehir En Az 3 Karakterli Olmalıdır");
            RuleFor(X => X.CustomerName).MinimumLength(2).WithMessage("İsim En Az 2 Karakterli Olmalıdır");
        }
    }
}
