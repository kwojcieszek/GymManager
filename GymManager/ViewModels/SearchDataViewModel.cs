using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using GymManager.Common;

namespace GymManager.ViewModels;

public class SearchDataViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand CloseCommand =>
        _closeCommand ??= new RelayCommand(
            x => { Window.Close(); });

    public string Description { get; set; }
    public Func<string, bool> Execute { get; set; }

    public ICommand SearchCommand =>
        _searchCommand ??= new RelayCommand(
            x =>
            {
                if (Execute(SearchText))
                    Window.Close();
            });

    public string SearchText { get; set; }

    public string Title { get; set; }
    public Window Window => Helper.GetWindow(this);
    private ICommand _closeCommand;
    private ICommand _searchCommand;

    private void OnPropertyChange([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}