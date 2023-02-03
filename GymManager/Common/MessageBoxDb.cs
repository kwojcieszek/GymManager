using System.Windows;
using GymManager.Views;

namespace GymManager.Common;

public static class MessageBoxDb
{
    public static void FieldMustBeCompleted(Window window, string filed, string message = null)
    {
        MessageView.MessageBoxInfoView(window, message ?? $"POLE '{filed}'\nMUSI ZOSTAC UZUPENIONE!", true);
    }
}