using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using GymManager.Common;
using GymManager.DataModel.Models;
using GymManager.Models;
using GymManager.Views;
using Microsoft.Win32;

namespace GymManager.ViewModels
{
    public class MemberEditViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly MemberEditModel _model = new();
        private ICommand _addCommand;
        private ICommand _applyCommand;
        private ICommand _cancelCommand;
        private ICommand _contentRenderedCommand;
        private ICommand _deleteCommand;
        private ICommand _editCommand;
        private ICommand _peselCommand;
        private ICommand _photoCameraCommand;
        private ICommand _photoFileCommand;
        private ICommand _photoRemoveCommand;
        private ICommand _refreshCommand;
        private ICommand _rfidCommand;
        private ICommand _rfidRemoveCommand;

        public ICommand AddCommand =>
            _addCommand ??= new RelayCommand(
                x =>
                {
                    if(AddPassRegistry())
                    {
                        OnPropertyChange(nameof(PassesRegistry));
                    }
                });

        public ICommand ApplyCommand =>
            _applyCommand ??= new RelayCommand(
                x =>
                {
                    if(CheckMember(_model.Member))
                    {
                        try
                        {
                            _model.SaveChanges();

                            Window.DialogResult = true;
                        }
                        catch(Exception ex)
                        {
                            MessageView.MessageBoxInfoView(Window, ex?.InnerException.Message, true);
                        }
                    }
                });

        public ICommand CancelCommand =>
            _cancelCommand ??= new RelayCommand(
                x => { Window.DialogResult = false; });

        public ICommand ContentRenderedCommand =>
            _contentRenderedCommand ??= new RelayCommand(
                x =>
                {
                    if(_model.Member == null)
                    {
                        Title = "DODAWANIE CZŁONKA SIŁOWNI";

                        _model.SetNewObject();

                        OnPropertyChange(nameof(Member));
                    }
                    else
                    {
                        Title = $"EDYCJA CZŁONKA SIŁOWNI [{_model.Member.FirstName} {_model.Member.LastName}]";

                        ContinuationText = _model.GetContinuationText();

                        SummaryOfDaysSubscriptionSuspensionText = _model.GetSummaryOfDaysSubscriptionSuspensionText();

                        IsEdit = true;

                        OnPropertyChange(nameof(IsEdit));
                        OnPropertyChange(nameof(Member));
                        OnPropertyChange(nameof(Photo));
                        OnPropertyChange(nameof(IdentifierKey));
                        OnPropertyChange(nameof(PassesRegistry));
                        OnPropertyChange(nameof(EntriesRegistry));
                        OnPropertyChange(nameof(ContinuationText));
                        OnPropertyChange(nameof(ContinuationText));
                        OnPropertyChange(nameof(SummaryOfDaysSubscriptionSuspensionText));
                    }

                    OnPropertyChange(nameof(Title));
                });

        public string ContinuationText { get; set; }

        public ICommand DeleteCommand =>
            _deleteCommand ??= new RelayCommand(
                x =>
                {
                    if(DeletePassRegistry())
                    {
                        OnPropertyChange(nameof(PassesRegistry));
                    }
                });

        public ICommand EditCommand =>
            _editCommand ??= new RelayCommand(
                x =>
                {
                    if(EditPassRegistry())
                    {
                        OnPropertyChange(nameof(PassesRegistry));
                    }
                });

        public List<EntryRegistry> EntriesRegistry => _model.EntriesRegistry;
        public List<Gender> Genders => _model.Genders;

        public string IdentifierKey
        {
            get => _model.IdentifierKey;
            set => _model.IdentifierKey = value;
        }

        public bool IsEdit { get; set; }

        public Member Member => _model.Member;

        public Window Owner
        {
            set => Window.Owner = value;
            get => Window.Owner;
        }

        public List<Pass> Passes => _model.Passes;
        public List<PassRegistry> PassesRegistry => _model.PassesRegistry;

        public ICommand PeselCommand =>
            _peselCommand ??= new RelayCommand(
                x =>
                {
                    if(_model.SetMemberPesel())
                    {
                        OnPropertyChange(nameof(Member));
                    }
                });

        public BitmapImage Photo
        {
            get
            {
                if(_model.PhotoData == null)
                {
                    return new BitmapImage(new Uri($"{Path.ApplicationDirectory}\\Images\\NoPhoto.png"));
                }

                return Helper.ImageToBitmapImage(_model.PhotoData);
            }
        }

        public ICommand PhotoCameraCommand =>
            _photoCameraCommand ??= new RelayCommand(
                x =>
                {
                    var data = new CameraService
                        {
                            PathExecute = $"{Path.ApplicationDirectory}\\Camera\\CameraView.exe",
                            MyPicturesLibraryFileName = "CameraCaptutre.jpg"
                        }
                        .Start();

                    if(data is { Length: > 0 })
                    {
                        _model.PhotoData = data;

                        OnPropertyChange(nameof(Photo));
                    }
                });

        public ICommand PhotoFileCommand =>
            _photoFileCommand ??= new RelayCommand(
                x =>
                {
                    var op = new OpenFileDialog
                    {
                        Title = "WYBIERZ ZDJĘCIE",
                        Filter = "JPNG PNG|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|PPNG (*.png)|*.png"
                    };

                    if(op.ShowDialog() == true)
                    {
                        _model.PhotoData = Helper.ImageToByteArray(Image.FromFile(op.FileName));

                        OnPropertyChange(nameof(Photo));
                    }
                });

        public ICommand PhotoRemoveCommand =>
            _photoRemoveCommand ??= new RelayCommand(
                x =>
                {
                    _model.RemovePhoto();

                    OnPropertyChange(nameof(Photo));
                });

        public ICommand RefreshCommand =>
            _refreshCommand ??= new RelayCommand(
                x => { OnPropertyChange(nameof(PassesRegistry)); });

        public ICommand RfidCommand =>
            _rfidCommand ??= new RelayCommand(
                x =>
                {
                    var view = new RfidView
                    {
                        Owner = Window
                    };

                    view.ShowDialog();

                    if(view.DataContext is RfidViewModel rfidViewModel)
                    {
                        if(rfidViewModel.Identifier != null)
                        {
                            IdentifierKey = rfidViewModel.Identifier;
                        }

                        OnPropertyChange(nameof(IdentifierKey));
                    }
                });

        public ICommand RfidRemoveCommand =>
            _rfidRemoveCommand ??= new RelayCommand(
                x =>
                {
                    _model.RemoveIdentifier();

                    OnPropertyChange(nameof(IdentifierKey));
                });

        public PassRegistry SelectedPassRegistry { get; set; }
        public string SummaryOfDaysSubscriptionSuspensionText { get; set; }
        public string Title { get; set; }
        public Window Window => Helper.GetWindow(this);

        public void SetEditObject(int memberID)
        {
            _model.SetEditObject(memberID);
        }

        private bool AddPassRegistry()
        {
            try
            {
                var passEditView = new PassesMembersEditView();
                var model = passEditView.DataContext as PassesMembersEditViewModel;
                model.Owner = Window;
                model.MemberInit = Member;

                return passEditView.ShowDialog().Value;
            }
            catch(Exception ex)
            {
                MessageView.MessageBoxInfoView(Window, ex.Message, true);

                return false;
            }
        }

        private bool CheckMember(Member member)
        {
            string filed = null;
            string message = null;

            if(_model.Member == null)
            {
                return false;
            }

            if(string.IsNullOrEmpty(member.Id))
            {
                filed = "ID";
            }
            else if(string.IsNullOrEmpty(member.FirstName))
            {
                filed = "IMIE";
            }
            else if(string.IsNullOrEmpty(member.LastName))
            {
                filed = "NAZWISKO";
            }
            else if(member.Gender == null)
            {
                filed = "PŁEĆ";
            }
            else if(string.IsNullOrEmpty(member.Street1))
            {
                filed = "ADRES 1";
            }
            else if(string.IsNullOrEmpty(member.City))
            {
                filed = "MIASTO";
            }
            else if(string.IsNullOrEmpty(member.PostCode))
            {
                filed = "KOD POCZTOWY";
            }
            else if(!string.IsNullOrEmpty(member.Email) && !EmailValidator.EmailIsValid(member.Email))
            {
                message = $"EMAIL '{member.Email}' MA NIEPRAWIDŁOWY FORMAT";
            }
            else if(!member.NoPeselNumber && (string.IsNullOrEmpty(member.Pesel) || !new Pesel().IsValid(member.Pesel.ToCharArray())))
            {
                message = $"PESEL '{member.Pesel}' MA NIEPRAWIDŁOWY FORMAT";
            }
            else
            {
                return true;
            }

            MessageBoxDb.FieldMustBeCompleted(Window, filed, message);

            return false;
        }

        private bool DeletePassRegistry()
        {
            if(SelectedPassRegistry == null)
            {
                return false;
            }

            var message =
                $"CZY NA PEWNO USUNĄĆ WPIS KARNETU\nID {SelectedPassRegistry.PassID} DLA {SelectedPassRegistry.Member.FirstName} {SelectedPassRegistry.Member.LastName} ?";

            if(MessageView.MessageBoxQuestionView(Window, message))
            {
                try
                {
                    new PassesMembersModel().Delete(SelectedPassRegistry);
                }
                catch(Exception ex)
                {
                    MessageView.MessageBoxInfoView(Window, ex?.InnerException.Message, true);

                    return false;
                }

                return true;
            }

            return false;
        }

        private bool EditPassRegistry()
        {
            if(SelectedPassRegistry == null)
            {
                return false;
            }

            try
            {
                var passEditView = new PassesMembersEditView();
                var model = passEditView.DataContext as PassesMembersEditViewModel;
                model.Owner = Window;
                model.SetEditObject(SelectedPassRegistry.PassRegistryID);

                return passEditView.ShowDialog().Value;
            }
            catch(Exception ex)
            {
                MessageView.MessageBoxInfoView(Window, ex.Message, true);

                return false;
            }
        }

        private void OnPropertyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}