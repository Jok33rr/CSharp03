
using System.Windows;

namespace NikitchenkoCSharp03
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new BirthdayRegisterViewModel(this);
        }
    }
}
