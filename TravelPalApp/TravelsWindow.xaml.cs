using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
    public partial class TravelsWindow : Window
    {
        public TravelsWindow()
        {
            InitializeComponent();

            UserLbl.Content = $"{UserManager.SignedInUser.Username}";

            if (UserManager.SignedInUser is User user)
            {
                AddTravelBtn.Visibility = Visibility.Visible;
                foreach (Travel trip in user.Travels)
                
                {
                    ListViewItem item = new ListViewItem();
                    item.Content = trip.Destination + " " + "(" + trip.GetType().Name.ToLower() + ")";
                    item.Tag = trip;

                    ListViewTravel.Items.Add(item);
                }
            }
            else if (UserManager.SignedInUser is Admin)
            {
                List<Travel> allTravels = TravelManager.Travels.ToList();
                AddTravelBtn.Visibility = Visibility.Hidden;
                InfoBtn.Visibility = Visibility.Hidden;

                foreach (Travel trip in allTravels)
                {
                    ListViewItem item = new ListViewItem();
                    item.Content = trip.Destination + " " + "(" + trip.GetType().Name.ToLower() + ")";
                    item.Tag = trip;

                    ListViewTravel.Items.Add(item);
                }
            }



        }
        private void InfoBtn_Click(object sender, RoutedEventArgs e)
          
        { 
           MessageBox.Show("TravelPal was created to be a tool and your best 'Pal' that helps you organize for your future trips.                                                                                              Click DETAILS for information about your trip.                                                       Click ADD TRAVEL to add a new trip.                                                              Click REMOVE to delete your chosen trip.");
             
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            UserManager.SignOutUser();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void AddTravelBtn_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow addTravelWindow = new AddTravelWindow();
            addTravelWindow.Show();
            Close();
        }

        private void DetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewTravel.SelectedItem == null)
            {
                MessageBox.Show("Select a trip", "Warning");
            }
            else
            {
                ListViewItem trip = (ListViewItem)ListViewTravel.SelectedItem;
                Travel selectedTravel = (Travel)trip.Tag;
                TravelDetailsWindow travelDetailsWindow = new TravelDetailsWindow (selectedTravel);
                travelDetailsWindow.Show();
                Close();
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewTravel.SelectedItem != null)
            {
                Travel selectedTravel = (Travel)((ListViewItem)ListViewTravel.SelectedItem).Tag;

                if (UserManager.SignedInUser is User || UserManager.SignedInUser is Admin)
                {
                    TravelManager.TravelRemove(selectedTravel);
                    ListViewTravel.Items.Remove(ListViewTravel.SelectedItem);
                }
            }
            else
            {
                MessageBox.Show("Select a trip", "Warning");
            }
        }

    }
}   
