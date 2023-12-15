using ApartmentManagementSystem.Domain.Entities;

namespace ApartmentManagementSystem.MVC.Models.Response
{
    public class DairesResponse
    {
        public string DaireNo { get; set; }

        public int FloorNo { get; set; }

        public AppUser User { get; set; }

        public List<Subscription> Subscriptions { get; set; }


    }
}
