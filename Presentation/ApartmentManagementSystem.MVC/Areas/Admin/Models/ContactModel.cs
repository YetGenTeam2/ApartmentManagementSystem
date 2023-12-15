namespace ApartmentManagementSystem.MVC.Areas.Admin.Models
{
    public class ContactModel
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
