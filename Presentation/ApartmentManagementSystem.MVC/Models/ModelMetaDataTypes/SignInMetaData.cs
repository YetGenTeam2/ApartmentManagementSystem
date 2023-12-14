using System.ComponentModel.DataAnnotations;

namespace ApartmentManagementSystem.MVC.Models.ModelMetaDataTypes
{
    public class SignInMetaData
    {
        [Required(ErrorMessage = "Lütfen e-posta adresinizi giriniz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        [Display(Name = "Şifre: ")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
