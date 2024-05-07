using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TravelPalApp
{
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();

            foreach (var country in Enum.GetValues(typeof(Countries)))
            {
                cbNewCountry.Items.Add(country);
            }


        }
        public void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = TxtUsername.Text;
            string password = txtPassword.Password;

            if (cbNewCountry.SelectedValue != null)
            {
                Countries countries = (Countries)cbNewCountry.SelectedValue;
             
            }
            else
            {
                MessageBox.Show("Please select a country", "Warning!");
                return;
            }

            Countries country = (Countries)cbNewCountry.SelectedValue;
            


            string confirmpassword = txtConfirmPassword.Password;
            
            // Kontrollerar så inga fält lämnas tomma
            if (string.IsNullOrWhiteSpace(username))
            {
               MessageBox.Show("Fill out Username", "Warning!");
            }
            else if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Enter New Password");
            }
            else if (string.IsNullOrWhiteSpace(confirmpassword))
            {
                MessageBox.Show("Confirm Password cannot be empty");
            }
            else if (password != confirmpassword)
            {
                // Om lösenordet inte stämmer i confirmpassword
                MessageBox.Show("Passwords do not match");
            }
            else
            {
                // Lägger till user i UserManager
                IUser user = new User (username, password, country);
                bool addedUser = UserManager.AddUser(user);
                if (addedUser)
                {
                    MessageBox.Show("User registered! Welcome!");
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Close();
                } 
                else
                // Om användarnamet är upptaget
                {
                    MessageBox.Show("Choose another Username");
                }

            }
        }
                 private void btnClose_Click(object sender, RoutedEventArgs e)
                  {
                     MainWindow mainWindow = new MainWindow();
                     mainWindow.Show();
                     Close();
                  }
    }
}


          