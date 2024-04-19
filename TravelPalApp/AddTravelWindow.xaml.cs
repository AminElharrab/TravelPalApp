using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
    public partial class AddTravelWindow : Window
    {
        public AddTravelWindow()
        {
            InitializeComponent();

            foreach (Countries country in Enum.GetValues(typeof(Countries)))
            {
                CountryCB.Items.Add(country);
            }
        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            string meetingDetails = HdnMeetingTextbox.Text;
            string destination = CityTxt.Text;
            Countries? country = CountryCB.SelectedItem as Countries?;
            int travellers;

            if (!int.TryParse(TravellersTxt.Text, out travellers) || travellers <= 0)
            {
                MessageBox.Show("Please enter a valid number of travelers.", "Warning!");
                return;
            }

            string? trip = (TripTypeCB.SelectedItem as ComboBoxItem)?.Content as string;
            User? signedInUser = UserManager.SignedInUser as User;

            if (string.IsNullOrEmpty(destination) || country == null || string.IsNullOrEmpty(trip))
            {
                MessageBox.Show("Please fill in all the required fields.", "Warning!");
                return;
            }
            else
            {
                if (trip == "Work Trip")
                {
                    if (string.IsNullOrEmpty(meetingDetails))
                    {
                        MessageBox.Show("Please provide meeting details for the work trip.", "Warning!");
                        return;
                    }

                    WorkTrip workTrip = new WorkTrip(destination, country.Value, travellers, meetingDetails);
                    if (signedInUser != null)
                    {
                        signedInUser.Travels.Add(workTrip);
                    }
                    else
                    {
                        MessageBox.Show("Did not pass");
                    }
                }
                else if (trip == "Vacation")
                {
                    bool? allInclusive = hdnAllinclusive.IsChecked;

                    if (allInclusive == null)
                    {
                        MessageBox.Show("Please specify if the vacation is all-inclusive.", "Warning!");
                        return;
                    }

                    Vacation vacation = new Vacation(destination, country.Value, travellers, allInclusive.Value);
                    if (signedInUser != null)
                    {
                        signedInUser.Travels.Add(vacation);
                    }
                    else
                    {
                        MessageBox.Show("Did not pass");
                    }
                }

                TravelsWindow travelsWindow = new TravelsWindow();
                travelsWindow.Show();
                Close();
            }
        }

        private void Exitbtn_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new TravelsWindow();
            travelsWindow.Show();
            Close();
        }

        private void TripTypeCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string? selectedContent = (TripTypeCB.SelectedItem as ComboBoxItem)?.Content as string;

            if (selectedContent == "Work Trip")
            {
                HdnMeetingLbl.Visibility = Visibility.Visible;
                HdnMeetingTextbox.Visibility = Visibility.Visible;
                hdnAllinclusive.Visibility = Visibility.Hidden;
            }
            else if (selectedContent == "Vacation")
            {
                hdnAllinclusive.Visibility = Visibility.Visible;
                HdnMeetingTextbox.Visibility = Visibility.Hidden;
                HdnMeetingLbl.Visibility = Visibility.Hidden;
            }
        }
    }
}
