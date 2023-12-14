using ApartmentManagementSystem.Domain.Entities;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
namespace ApartmentManagementSystem.MVC.Models.Validators
{
    public class SignUpValidator : AbstractValidator<AppUser>
    {
        public SignUpValidator()
        {
            RuleFor(x => x.firstName)
    .NotEmpty().WithMessage("Ad boş olamaz!")
    .NotNull().WithMessage("Ad null olamaz!")
    .Length(3, 20).WithMessage("Ad 3 ile 20 karakter arasında olmalıdır!");

            RuleFor(x => x.lastName)
                .NotEmpty().WithMessage("Soyad boş olamaz!")
                .NotNull().WithMessage("Soyad null olamaz!")
                .Length(3, 20).WithMessage("Soyad 3 ile 20 karakter arasında olmalıdır!");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş olamaz!")
                .Matches(@"^(\d{10})$").WithMessage("Telefon numarası 10 basamaklı olmalıdır!");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresi boş olamaz!")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz!");

        }
    }

}
