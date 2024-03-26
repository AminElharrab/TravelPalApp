using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TravelPalApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            Close();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            bool SignInUser = UserManager.SignInUser(username, password);
            
            if (SignInUser)
            {
                MessageBox.Show("Login Successful");
                TravelsWindow travelsWindow = new TravelsWindow();
                travelsWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Invalid Login Credentials");
            }
        }
    }
}