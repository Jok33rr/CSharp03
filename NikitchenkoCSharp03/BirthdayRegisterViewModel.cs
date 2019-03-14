using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace NikitchenkoCSharp03
{
    class BirthdayRegisterViewModel
    {
        private readonly Window _mainWindow;

        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDate = DateTime.Today;
        private RelayCommand _resultCommand;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return _birthDate;
            }
            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }

        public string BirthDateText { get; set; }

        public RelayCommand RegisterCommand
        {
            get
            {
                return _resultCommand ?? (_resultCommand = new RelayCommand(RegisterImpl,
                           o => !string.IsNullOrWhiteSpace(_name) &&
                                !string.IsNullOrWhiteSpace(_surname) &&
                                !string.IsNullOrWhiteSpace(_email) &&
                                !string.IsNullOrWhiteSpace(BirthDateText)
                                ));
            }
        }

        private async void RegisterImpl(object o)
        {
            User user = null;
            await Task.Run((() =>
            {
                try
                {
                    user = new User(_name, _surname, _email, _birthDate);
                }
                catch (UserCreationException e)
                {
                    MessageBox.Show(e.Message);
                }

            }));
            if (user == null)
                return;

            UserInfoWindow userInfoWindow = new UserInfoWindow(user);

            _mainWindow.Hide();
            userInfoWindow.Show();
        }

        internal BirthdayRegisterViewModel(Window mainWindow)
        {
            _mainWindow = mainWindow;
        }



        #region Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

