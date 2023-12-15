using ApartmentManagementSystem.Domain.Entities;
using FluentValidation;
using System.Data;

namespace ApartmentManagementSystem.MVC.Models.Validators
{
    public class DairesValidator: AbstractValidator<Daire>
    {
        public DairesValidator()
        {
            RuleFor(x => x.daireNo)
                .NotEmpty().WithMessage("HATA!: Daire No boş olamaz!");
                

            RuleFor(x => x.floorNo)
                .NotEmpty().WithMessage("HATA!: Kat No boş olamaz!");

            RuleFor(x => x.user.Id)
                .NotEmpty().WithMessage("HATA!: Daire kullanıcısı boş olamaz!");

            RuleFor(x => x.subscriptions)
                .NotEmpty().WithMessage("HATA!: Daire aidatı boş olamaz!");

        }
    }
}
