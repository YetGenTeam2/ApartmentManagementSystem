namespace ApartmentManagementSystem.MVC.Services
{
    public interface IToasterService 
    {
        void ShowSuccess(string message);

        void ShowInfo(string message);

        void ShowWarning(string message);
        void ShowError(string message);
    }
}
