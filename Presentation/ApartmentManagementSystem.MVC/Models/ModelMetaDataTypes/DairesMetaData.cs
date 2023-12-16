using ApartmentManagementSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ApartmentManagementSystem.MVC.Models.ModelMetaDataTypes
{
    public class DairesMetaData
    {

        [Required(ErrorMessage = "Lütfen daire numaranızı giriniz.")]
        public string DaireNo { get; set; }


        [Required(ErrorMessage = "Lütfen kat numaranızı giriniz.")]
        public int FloorNo { get; set; }


        [Required(ErrorMessage = "Lütfen daire sahibinin bilgilerini giriniz.")]
        public string UserId { get; set; }


        [Required(ErrorMessage = "Lütfen daire aidatını giriniz.")]
        public decimal Subscriptions { get; set; }



    }
}
