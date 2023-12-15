using System.ComponentModel.DataAnnotations;

namespace ApartmentManagementSystem.MVC.Areas.Admin.Models
{
    public class RoleCreateViewModel
    {
        [Required(ErrorMessage = "Rol ismi boş bırakılamaz.")]
        [Display(Name = "Rol ismi")]
        public string Name { get; set; }
    }
}
