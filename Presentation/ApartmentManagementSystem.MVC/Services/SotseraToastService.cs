using Sotsera.Blazor.Toaster;

namespace ApartmentManagementSystem.MVC.Services
{
    public class SotseraToastService : IToasterService
    {
        private readonly IToaster _toaster;

        public SotseraToastService(IToaster toaster)
        {
            _toaster = toaster;
        }

        public void ShowError(string message)
        {
            _toaster.Error(message);
        }

        public void ShowInfo(string message)
        {
            _toaster.Info(message);
        }

        public void ShowSuccess(string message)
        {
            _toaster.Success(message);
        }

        public void ShowWarning(string message)
        {
            _toaster.Warning(message);
        }
    }
}
