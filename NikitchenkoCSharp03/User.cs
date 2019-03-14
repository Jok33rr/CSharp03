using System;
using System.Linq;


namespace NikitchenkoCSharp03

{
    public class UserCreationException : Exception
    {
        public UserCreationException(string message)
            : base(message)
        {
        }
    }

    public class UnrealNameException : UserCreationException
    {
        public UnrealNameException(string message)
            : base(message)
        {
        }
    }

    public class UnrealSurnameException : UserCreationException
    {
        public UnrealSurnameException(string message)
            : base(message)
        {
        }
    }

    public class UnrealEmailException : UserCreationException
    {
        public UnrealEmailException(string givenEmail)
            : base($"Email {givenEmail} не є дійсним!")
        {
        }
    }

    public class UnrealBirthdayException : UserCreationException
    {
        public UnrealBirthdayException(DateTime birthday)
            : base($"Дата народження {birthday.ToShortDateString()} не є можливою!")
        {
        }
    }
    public class User
    {
        internal readonly string Name;
        internal readonly string Surname;
        internal readonly string Email;
        internal readonly DateTime Birthday;

        public User(string name, string surname, string email, DateTime birthday)
        {
            if (name.Length < 2)
            {
                throw new UnrealNameException($"Ім'я {name} занадто коротке!");
            }

            if (surname.Length < 3)
            {
                throw new UnrealSurnameException($"Прізвище {surname} занадто коротке!");
            }

            if (email.Length < 3 || email.Count(f => f == '@') != 1 ||
                (email.IndexOf("@", StringComparison.Ordinal) == email.Length - 1) ||
                (email.IndexOf("@", StringComparison.Ordinal) == 0))
            {
                throw new UnrealEmailException(email);
            }

            var unrealDate = DateTime.Today.YearsOld(birthday);
            if (unrealDate < 0 || unrealDate > 135)
            {
                throw new UnrealBirthdayException(birthday);
            }

            Name = name;
            Surname = surname;
            Email = email;
            Birthday = birthday;
        }
        public bool IsAdult => DateTime.Today.YearsOld(Birthday) >= 18;
        public bool IsBirthday => DateTime.Today.DayOfYear == Birthday.DayOfYear;
        public User(string name, string surname, string email) : this(name, surname, email, DateTime.Today) { }
        public User(string name, string surname, DateTime birthday) : this(name, surname, "not specified", birthday) { }
        public string ChineseSign
        {
            get
            {
                int sign = Birthday.Year % 12;
                switch (sign)
                {
                    case 0:
                        return "Рік Мавпи";

                    case 1:
                        return "Год Півня";
                    case 2:
                        return "Рік Собаки";
                    case 3:
                        return "Рік Свині";
                    case 4:
                        return "Рік Пацюка";
                    case 5:
                        return "Рік Бика";
                    case 6:
                        return "Рік Тигра";
                    case 7:
                        return "Рік Кролика";
                    case 8:
                        return "Рік Дракона";
                    case 9:
                        return "Рік Змії";
                    case 10:
                        return "Рік Коня";
                    case 11:
                        return "Рік Кози";

                }
                return "";
            }
        }
        public string SunSign
        {
            get
            {
                var day = Birthday.Day;
                var month = Birthday.Month;
                if (day == -1)
                    return "Error Code -1";
                if (day > 21 && month == 12 || day < 20 && month == 1)
                    return "Козерог";
                else if (day > 19 && month == 1 || day < 19 && month == 2)
                    return "Водолій";
                else if (day > 18 && month == 2 || day < 21 && month == 3)
                    return "Риби";
                else if (day > 20 && month == 3 || day < 20 && month == 4)
                    return "Овен";
                else if (day > 19 && month == 4 || day < 21 && month == 5)
                    return "Телець";
                else if (day > 20 && month == 5 || day < 21 && month == 6)
                    return "Близнюки";
                else if (day > 20 && month == 6 || day < 23 && month == 7)
                    return "Рак";
                else if (day > 22 && month == 7 || day < 23 && month == 8)
                    return "Лев";
                else if (day > 22 && month == 8 || day < 23 && month == 9)
                    return "Діва";
                else if (day > 22 && month == 9 || day < 23 && month == 10)
                    return "Терези";
                else if (day > 22 && month == 10 || day < 22 && month == 11)
                    return "Скорпіон";
                else if (day > 21 && month == 11 || day < 22 && month == 12)
                    return "Стрілець";
                else
                    return "Козеріг";

            }
        }
    }
}

