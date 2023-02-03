using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using GymManager.Common;
using GymManager.Models;
using GymManager.Views;
using Ookii.Dialogs.Wpf;

namespace GymManager.ViewModels;

public class DatabasesSettingsViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand ApplyCommand =>
        _applyCommand ??= new RelayCommand(
            x =>
            {
                if (SqlServer)
                    _model.DatabaseSettings.DatabaseType = DatabaseTypes.SqlServer;
                else if (Sqlite)
                    _model.DatabaseSettings.DatabaseType = DatabaseTypes.Sqlite;
                else if (PostgreSql)
                    _model.DatabaseSettings.DatabaseType = DatabaseTypes.PostgreSql;
                else if (MySql)
                    _model.DatabaseSettings.DatabaseType = DatabaseTypes.MySql;

                try
                {
                    DbModels.Engines.Migrations.Migration(Settings.App.Databases.DatabaseType);
                }
                catch (Exception exp)
                {
                    MessageView.MessageBoxInfoView(Window, exp.Message, true);

                    return;
                }

                SettingsConfiguration.Set();

                _model.Save();

                Window.DialogResult = true;
            });

    public ICommand CancelCommand =>
        _cancelCommand ??= new RelayCommand(
            x =>
            {
                _model.Restore();

                SettingsConfiguration.Set();

                Window.DialogResult = false;
            });

    public DatabasesSettings DatabasesSettings => _model.DatabaseSettings;
    public bool MySql { get; set; } = Settings.App.Databases.DatabaseType == DatabaseTypes.MySql;

    public Window Owner
    {
        set => Window.Owner = value;
        get => Window.Owner;
    }

    public bool PostgreSql { get; set; } = Settings.App.Databases.DatabaseType == DatabaseTypes.PostgreSql;
    public bool Sqlite { get; set; } = Settings.App.Databases.DatabaseType == DatabaseTypes.Sqlite;

    public ICommand SqliteDirectoryCommand =>
        _sqliteDirectoryCommand ??= new RelayCommand(
            x =>
            {
                var dialog = new VistaFolderBrowserDialog
                {
                    ShowNewFolderButton = true,
                    SelectedPath = DatabasesSettings.Sqlite.Directory
                };

                if (dialog.ShowDialog(Window).GetValueOrDefault())
                {
                    DatabasesSettings.Sqlite.Directory = dialog.SelectedPath;

                    OnPropertyChange(nameof(DatabasesSettings));
                }

                ;
            });

    public bool SqlServer { get; set; } = Settings.App.Databases.DatabaseType == DatabaseTypes.SqlServer;
    public Window Window => Helper.GetWindow(this);
    private ICommand _applyCommand;
    private ICommand _cancelCommand;
    private readonly DatabaseSettingsModel _model = new();
    private ICommand _sqliteDirectoryCommand;

    private void OnPropertyChange([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}