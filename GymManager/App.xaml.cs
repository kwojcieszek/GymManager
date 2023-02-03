﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using GymManager.Common;

namespace GymManager;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static bool ApplicationMainWindowIsActive { get; set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        SetupUnhandledExceptionHandling();

        base.OnStartup(e);
    }

    private void SetupUnhandledExceptionHandling()
    {
        // Catch exceptions from all threads in the AppDomain.
        AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            ShowUnhandledException(args.ExceptionObject as Exception, "AppDomain.CurrentDomain.UnhandledException",
                false);

        // Catch exceptions from each AppDomain that uses a task scheduler for async operations.
        TaskScheduler.UnobservedTaskException += (sender, args) =>
            ShowUnhandledException(args.Exception, "TaskScheduler.UnobservedTaskException", false);

        // Catch exceptions from a single specific UI dispatcher thread.
        Dispatcher.UnhandledException += (sender, args) =>
        {
            // If we are debugging, let Visual Studio handle the exception and take us to the code that threw it.
            if (!Debugger.IsAttached)
            {
                args.Handled = true;
                ShowUnhandledException(args.Exception, "Dispatcher.UnhandledException", true);
            }
        };

        // Catch exceptions from the main UI dispatcher thread.
        // Typically we only need to catch this OR the Dispatcher.UnhandledException.
        // Handling both can result in the exception getting handled twice.
        Current.DispatcherUnhandledException += (sender, args) =>
        {
            // If we are debugging, let Visual Studio handle the exception and take us to the code that threw it.
            if (!Debugger.IsAttached)
            {
                args.Handled = true;
                ShowUnhandledException(args.Exception, "Application.Current.DispatcherUnhandledException", true);
            }
        };
    }

    private void ShowUnhandledException(Exception e, string unhandledExceptionType, bool promptUserForShutdown)
    {
        Logger.Log.Error(e);

        var messageBoxTitle = $"Unexpected Error Occurred: {unhandledExceptionType}";
        var messageBoxMessage = $"The following exception occurred:\n\n{e}";
        var messageBoxButtons = MessageBoxButton.OK;

        // Let the user decide if the app should die or not (if applicable).
        MessageBox.Show(messageBoxMessage, messageBoxTitle, messageBoxButtons);
    }
}