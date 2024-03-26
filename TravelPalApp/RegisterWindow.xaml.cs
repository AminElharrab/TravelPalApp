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

            //string[] Countries = Enum.GetNames(typeof(Countries));
            //foreach (string country in Countries)
            //{
            //    cbNewCountry.Items.Add(country);
            //}

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
                MessageBox.Show("Passwords do not match");
            }
            else
            {
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
                {
                    MessageBox.Show("Choose another username");
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


          