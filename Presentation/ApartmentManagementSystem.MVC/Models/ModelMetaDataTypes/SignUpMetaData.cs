using System.ComponentModel.DataAnnotations;

namespace ApartmentManagementSystem.MVC.Models.ModelMetaDataTypes
{
    public class SignUpMetaData
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "Lütfen adınızı giriniz.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Adınız 3 ile 20 karakter arasında olmalıdır.")]
        public string? firstName { get; set; }
        [Required(ErrorMessage = "Lütfen soyadınızı giriniz.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Adınız 3 ile 20 karakter arasında olmalıdır.")]
        public string? lastName { get; set; }
        [Required(ErrorMessage = "Lütfen telefon numaranızı giriniz.")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Telefon numarası 10 basamaklı olmalıdır.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Lütfen e-posta adresinizi giriniz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        [Display(Name = "Şifre: ")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Girmiş olduğunuz şifreler eşleşmemektedir.")]
        [Required(ErrorMessage = "Şifre tekrar alanı boş bırakılamaz.")]
        [Display(Name = "Şifre Tekrar: ")]
        public string PasswordConfirm { get; set; }

    }
}
