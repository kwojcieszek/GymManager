using System.Windows;
using GymManager.Common;
using GymManager.DataService.Common;
using GymManager.Views;

namespace GymManager.ViewModels
{
    public static class CommonViewModel
    {
        public static void AddEntryWithoutIdentifierCommand(Window window = null)
        {
            if(!PermissionView.MessageBoxCheckPermissionView(window, Permissions.AddEntryWithoutIdentifier))
            {
                return;
            }

            var view = new MembersView
            {
                Owner = window
            };

            var dx = view.DataContext as MembersViewModel;
            dx.CloseWhenDoubleClick = true;

            var result = view.ShowDialog();

            if(result.HasValue & result.Value && dx.SelectedItem != null)
            {
                var entryRegistry = PassesHelper.GetActiveEntryRegistry(dx.SelectedItem);

                if(entryRegistry == null &&
                   new IdentifiersService().Identifier(dx.SelectedItem.MemberID, checkAndWrite: false)
                       .Message !=
                   IdentifierMessage.AccessEntry)
                {
                    if(MessageView.MessageBoxQuestionView(window,
                           $"BRAK WAŻNEGO KARNETU!\nMIMO TO CZY CHCESZ DODAĆ 'WEJŚCIE' DLA\n{dx.SelectedItem.FirstName} {dx.SelectedItem.LastName} [{dx.SelectedItem.Id}] ?"))
                    {
                        EntryService.GetInstance().Entry(dx.SelectedItem, true);
                    }
                }
                else
                {
                    if(MessageView.MessageBoxQuestionView(window,
                           $"CZY CHCESZ DODAĆ '{(entryRegistry == null ? "WEJŚCIE" : "WYJŚCIE")}' DLA\n{dx.SelectedItem.FirstName} {dx.SelectedItem.LastName} [{dx.SelectedItem.Id}] ?"))
                    {
                        EntryService.GetInstance().Entry(dx.SelectedItem);
                    }
                }
            }
        }
    }
}