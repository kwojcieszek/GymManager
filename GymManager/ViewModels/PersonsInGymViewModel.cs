using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using GymManager.Common;
using GymManager.DbModels;
using GymManager.Models;
using GymManager.Views;

namespace GymManager.ViewModels;

public class PersonsInGymViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand CloseCommand =>
        _closeCommand ??= new RelayCommand(
            x => { Window.DialogResult = false; });

    public ICommand CloseRowCommand =>
        _closeRowCommand ??= new RelayCommand(
            x =>
            {
                if (CloseRow())
                {
                    _model.GetEntriesRegistry();
                    OnPropertyChange(nameof(EntriesRegistry));
                }
            });

    public List<EntryRegistry> EntriesRegistry =>
        _model.EntriesRegistry
            .Like(_searchText, "Member.Id", "Member.FirstName", "Member.LastName", "CabinetKey.Name")
            .OrderByDescending(m => m.EntryDate).ToList();

    public ICommand RefreshCommand =>
        _refreshCommand ??= new RelayCommand(
            x =>
            {
                _model.GetEntriesRegistry();
                OnPropertyChange(nameof(EntriesRegistry));
            });

    public string SearchText
    {
        set
        {
            _searchText = value;

            OnPropertyChange(nameof(EntriesRegistry));
        }
    }

    public ICommand SearchTextCommand =>
        _searchTextCommand ??= new RelayCommand(
            x => { OnPropertyChange(nameof(EntriesRegistry)); });

    public EntryRegistry SelectedItem { get; set; }

    public Window Window => Helper.GetWindow(this);
    private ICommand _closeCommand;
    private ICommand _closeRowCommand;
    private readonly PersonsInGymModel _model = new();
    private ICommand _refreshCommand;
    private string _searchText = string.Empty;
    private ICommand _searchTextCommand;

    private bool CloseRow()
    {
        if (SelectedItem == null)
            return false;

        var message =
            $"CZY NA PEWNO ZAMKNĄĆ REKORD OSOBY\n{SelectedItem.Member.FirstName} {SelectedItem.Member.LastName} [{SelectedItem.Member.Id}] ?";

        if (MessageView.MessageBoxQuestionView(Window, message))
        {
            try
            {
                _model.CloseRow(SelectedItem);
            }
            catch (Exception ex)
            {
                if (ex?.InnerException != null)
                    MessageView.MessageBoxInfoView(Window, ex?.InnerException.Message, true);

                return false;
            }

            return true;
        }

        return false;
    }

    private void OnPropertyChange([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}