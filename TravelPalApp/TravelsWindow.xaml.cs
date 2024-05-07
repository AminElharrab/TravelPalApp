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

            // Displayar SignedinUser användarnamn
            UserLbl.Content = $"{UserManager.SignedInUser.Username}";


            // Hanterar visibilty för admin/user och lägger till trips i listview
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
                AddTravelBtn.Visibility = Visibility.Hidden;
                InfoBtn.Visibility = Visibility.Hidden;
                List<Travel> allTravels = TravelManager.Travels.ToList();
                allTravels = TravelManager.GetAllUserTravels();

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
            // Varningsmeddelande om ingen resa väljs
            if (ListViewTravel.SelectedItem == null)
            {
                MessageBox.Show("Select a trip", "Warning");
            }
            else
            {
                //displayar detaljer kring en vald resa
                ListViewItem trip = (ListViewItem)ListViewTravel.SelectedItem;
                Travel selectedTravel = (Travel)trip.Tag;
                TravelDetailsWindow travelDetailsWindow = new TravelDetailsWindow(selectedTravel);
                travelDetailsWindow.Show();
                Close();
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
           
            if (ListViewTravel != null && ListViewTravel.SelectedItem != null)
            {
                ListViewItem selectedItem = (ListViewItem)ListViewTravel.SelectedItem;
                Travel selectedTravel = (Travel)selectedItem.Tag;

                if (UserManager.SignedInUser is User)
                {
                    // Raderar resa från den inloggade User
                    User user = UserManager.SignedInUser as User;
                    _ = user.Travels.Remove(selectedTravel);
                }
                else if (UserManager.SignedInUser is Admin)
                {
                    // Filtrera till endast users från UserManager
                    IEnumerable<User> normalUser = UserManager.users.OfType<User>();
                    foreach (User user in normalUser)
                    {
                        if (user.Travels.Contains(selectedTravel))
                        {
                            // Raderar valda resan från User
                            user.Travels.Remove(selectedTravel);
                            break;
                        }
                    }
                }
                // Raderar valda resan från List view
                ListViewTravel.Items.Remove(selectedItem);
            }
            else
            {
                // Varningsmeddelande om ingen resa väljs
                MessageBox.Show("Select a trip", "Warning");
            }
        }
    }
}





