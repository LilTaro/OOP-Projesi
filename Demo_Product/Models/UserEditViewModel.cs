using System.ComponentModel.DataAnnotations;

namespace Demo_Product.Models
{
    public class UserEditViewModel
    {
        [Required(ErrorMessage = "Lütfen Bir İsim Giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Bir Soyisim Giriniz")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen Bir Mail Giriniz")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen Bir Şifre Giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen Şifreyi Tekrar Giriniz")]
        [Compare("Password", ErrorMessage = "Lütfen Şifrenin Eşleştiğinden Emin Olun")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Lütfen Cinsiyet Seçiniz")]
        public string Gender { get; set; }
    }
}
