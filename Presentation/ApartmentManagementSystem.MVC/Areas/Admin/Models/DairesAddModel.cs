using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApartmentManagementSystem.MVC.Areas.Admin.Models
{
    public class DairesAddModel
    {
        public string DaireNo { get; set; }

        public int FloorNo { get; set; }

        public string UserId { get; set; }

        public decimal Subscriptions { get; set; }

       
    }
}
