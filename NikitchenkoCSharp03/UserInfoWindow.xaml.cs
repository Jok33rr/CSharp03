using System;
using System.Windows;


namespace NikitchenkoCSharp03
{

    public partial class UserInfoWindow : Window
    {
        public UserInfoWindow(User user)
        {
            InitializeComponent();
            DataContext = new BirthdayViewModel(user);

        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

    }
}
