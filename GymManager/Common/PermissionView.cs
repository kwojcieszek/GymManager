using System.Windows;
using GymManager.DataService.Common;
using GymManager.ViewModels;
using GymManager.Views;

namespace GymManager.Common
{
    public static class PermissionView
    {
        public static bool MessageBoxCheckPermissionView(Window window, Permissions permission)
        {
            if(!CheckAccess(permission))
            {
                var msg = new MessageBoxInfoView();
                var model = msg.DataContext as MessageBoxInfoViewModel;
                model.Message = "BRAK DOSTĘPU DO ZASOBU";
                model.IsWarrning = true;
                msg.Owner = window;
                msg.ShowDialog();

                return false;
            }

            return true;
        }

        private static bool CheckAccess(Permissions permission)
        {
            return CurrentUser.CheckAccess(permission);
        }
    }
}