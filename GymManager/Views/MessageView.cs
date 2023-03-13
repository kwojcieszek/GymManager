using System.Windows;
using GymManager.ViewModels;

namespace GymManager.Views
{
    public static class MessageView
    {
        public static void MessageBoxInfoView(Window window, string message, bool isWarrning = false)
        {
            var msg = new MessageBoxInfoView();
            var model = msg.DataContext as MessageBoxInfoViewModel;
            model.Message = message;
            model.IsWarrning = isWarrning;
            msg.Owner = window;
            msg.ShowDialog();
        }

        public static bool MessageBoxQuestionView(Window window, string message)
        {
            var msg = new MessageBoxQuestionView();
            var model = msg.DataContext as MessageBoxQuestionViewModel;
            model.Message = message;
            msg.Owner = window;
            var result = msg.ShowDialog();
            return result ?? false;
        }
    }
}