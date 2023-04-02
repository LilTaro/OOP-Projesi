using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Demo_Product.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage ="Lütfen Bir İsim Giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Bir Soyisim Giriniz")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen Bir Kullancı Adı Giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Bir Mail Giriniz")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen Bir Şifre Giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen Şifreyi Tekrar Giriniz")]
        [Compare("Password",ErrorMessage ="Lütfen Şifrenin Eşleştiğinden Emin Olun")]
        public string ConfirmPassword { get; set; }
    }
}
