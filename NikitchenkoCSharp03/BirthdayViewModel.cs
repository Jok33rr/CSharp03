using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace NikitchenkoCSharp03
{
    class BirthdayViewModel : INotifyPropertyChanged
    {
        private readonly User _user;

        public string ZodiacWest
        {
            get
            {
                return $"Ваш західний знак: \n{_user.SunSign}";
            }

        }
        public string ZodiacChinese
        {
            get
            {
                return $"Ваш китайський знак: \n{_user.ChineseSign}";
            }

        }
        public string IsBirthday
        {
            get
            {
                return $"Сьогодні {(_user.IsBirthday ? "" : "не ")}ваш день народження";
            }
        }
        public string IsAdult
        {
            get
            {
                return $"Ви {(_user.IsAdult ? "" : "не ")}дорослий";
            }
        }
        public string Name
        {
            get
            {
                return $"Ваше ім'я:\n{_user.Name}";
            }
        }
        public string Surname
        {
            get
            {
                return $"Ваше прізвище:\n{_user.Surname}";
            }
        }
        public string Email
        {
            get
            {
                return $"Ваш email:\n{_user.Email}";
            }
        }
        public string BirthDate
        {
            get
            {
                return $"Ваш день народження:\n{_user.Birthday.ToShortDateString()}";
            }
        }

        public BirthdayViewModel(User user)
        {
            _user = user;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}


