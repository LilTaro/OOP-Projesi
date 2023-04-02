using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(X => X.ProductName).NotEmpty().WithMessage("Ürün Adını Boş Geçemezsiniz");
            RuleFor(X => X.ProductName).MinimumLength(3).WithMessage("Ürün Adı En Az 3 Karakter Olmalıdır");
            RuleFor(X => X.ProductStock).NotEmpty().WithMessage("Stok Sayısı Boş Geçilemez");
            RuleFor(X => X.ProductPrice).NotEmpty().WithMessage("Fiyat Boş Olamaz");
        }
    }
}
