using ApartmentManagementSystem.Domain.Entities;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
namespace ApartmentManagementSystem.MVC.Models.Validators
{
    public class SignInValidator : AbstractValidator<AppUser>
    {
        public SignInValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresi boş olamaz!")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz!");

        }
    }

}
