using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using app.Resources;

namespace app
{
    public partial class MainPage : PhoneApplicationPage
    {
        ServiceReferenceLength.lengthUnitSoapClient lengthClient = new ServiceReferenceLength.lengthUnitSoapClient();

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();

            foreach (var unit in Enum.GetNames(typeof(ServiceReferenceLength.Lengths))) {
                InputUnit.Items.Add(unit);
                OutputUnit.Items.Add(unit);
            }
        }

        private void ButtonDistance_Click(object sender, RoutedEventArgs e)
        {
            ServiceReferenceLength.Lengths inputUnit = (ServiceReferenceLength.Lengths)Enum.Parse(typeof(ServiceReferenceLength.Lengths), InputUnit.SelectedItem.ToString()),
                                outputUnit = (ServiceReferenceLength.Lengths)Enum.Parse(typeof(ServiceReferenceLength.Lengths), OutputUnit.SelectedItem.ToString());

            lengthClient.ChangeLengthUnitCompleted += lengthClient_ChangeLengthUnitCompleted;
            lengthClient.ChangeLengthUnitAsync(double.Parse(InputValue.Text), inputUnit, outputUnit);
        }

        private void lengthClient_ChangeLengthUnitCompleted(object sender, ServiceReferenceLength.ChangeLengthUnitCompletedEventArgs e)
        {
            OutputValue.Text = e.Result.ToString();
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}