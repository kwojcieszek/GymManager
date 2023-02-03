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

public class DataTrackingsViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand CloseCommand =>
        _closeCommand ??= new RelayCommand(
            x => { Window.DialogResult = false; });

    public List<DataTracking> DataTrackings =>
        _model.DataTrackings
            .Like(_searchText, "DataTrackingID", "PrimaryKey", "TableName", "User.FirstName", "User.LastName")
            .ToList();

    public DateTime DateFrom
    {
        get => _dateFrom;
        set
        {
            _dateFrom = value;
            _model.GetDataTrackings(_dateFrom, _dateTo);

            OnPropertyChange(nameof(DataTrackings));
        }
    }

    public DateTime DateTo
    {
        get => _dateTo;
        set
        {
            _dateTo = value;
            _model.GetDataTrackings(_dateFrom, _dateTo);

            OnPropertyChange(nameof(DataTrackings));
        }
    }

    public ICommand PreviewCommand =>
        _previewCommand ??= new RelayCommand(
            x =>
            {
                if (SelectedItem == null)
                    return;

                try
                {
                    var dataTrackingsPreviewView = new DataTrackingsPreviewView();
                    var model = dataTrackingsPreviewView.DataContext as DataTrackingsPreviewViewModel;
                    model.Owner = Window;
                    model.DataTracking = SelectedItem;
                    dataTrackingsPreviewView.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageView.MessageBoxInfoView(Window, ex.Message, true);
                }
            });

    public ICommand RefreshCommand =>
        _refreshCommand ??= new RelayCommand(
            x =>
            {
                _model.GetDataTrackings(_dateFrom, _dateTo);

                OnPropertyChange(nameof(DataTrackings));
            });

    public string SearchText
    {
        set
        {
            _searchText = value;

            OnPropertyChange(nameof(DataTrackings));
        }
    }

    public DataTracking SelectedItem { get; set; }

    public Window Window => Helper.GetWindow(this);
    private ICommand _closeCommand;
    private DateTime _dateFrom = DateTime.Now.Date.AddMonths(-1);
    private DateTime _dateTo = DateTime.Now.Date;
    private readonly DataTrackingsModel _model = new();
    private ICommand _previewCommand;
    private ICommand _refreshCommand;
    private string _searchText = string.Empty;

    public DataTrackingsViewModel()
    {
        _model.GetDataTrackings(_dateFrom, _dateTo);
    }

    private void OnPropertyChange([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}