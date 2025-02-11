﻿using System.ComponentModel.DataAnnotations;

namespace ApartmentManagementSystem.MVC.Areas.Admin.Models
{
    public class RoleUpdateViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Role isim alanı bpş bırakılamaz")]
        [Display(Name = "Rol ismi: ")]
        public string Name { get; set; }
    }
}
