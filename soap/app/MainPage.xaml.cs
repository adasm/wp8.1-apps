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
        ServiceReferenceWeight.ConvertWeightsSoapClient weightClient = new ServiceReferenceWeight.ConvertWeightsSoapClient();

        private static string converterDistanceName = "Distance";
        private static string converterWeightName = "Weight";

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();

            ConverterType.Items.Add(converterDistanceName);
            ConverterType.Items.Add(converterWeightName);
        }

        private void ConverterType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InputUnit.Items.Clear();
            OutputUnit.Items.Clear();

            if (ConverterType.SelectedItem.ToString().Equals(converterDistanceName))
            {
                foreach (var unit in Enum.GetNames(typeof(ServiceReferenceLength.Lengths)))
                {
                    //if (unit.Equals("Meters") || unit.Equals("Kilometers"))
                    {
                        InputUnit.Items.Add(unit);
                        OutputUnit.Items.Add(unit);
                    }
                }
            }
            else if (ConverterType.SelectedItem.ToString().Equals(converterWeightName))
            {
                foreach (var unit in Enum.GetNames(typeof(ServiceReferenceWeight.WeightUnit)))
                {
                    //if (unit.Equals("Meters") || unit.Equals("Kilometers"))
                    {
                        InputUnit.Items.Add(unit);
                        OutputUnit.Items.Add(unit);
                    }
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ConverterType.SelectedItem.ToString().Equals(converterDistanceName))
            {
                ServiceReferenceLength.Lengths inputUnit = (ServiceReferenceLength.Lengths)Enum.Parse(typeof(ServiceReferenceLength.Lengths), InputUnit.SelectedItem.ToString()),
                                outputUnit = (ServiceReferenceLength.Lengths)Enum.Parse(typeof(ServiceReferenceLength.Lengths), OutputUnit.SelectedItem.ToString());

                lengthClient.ChangeLengthUnitCompleted += lengthClient_ChangeLengthUnitCompleted;
                lengthClient.ChangeLengthUnitAsync(double.Parse(InputValue.Text), inputUnit, outputUnit);
            }
            else if (ConverterType.SelectedItem.ToString().Equals(converterWeightName))
            {
                ServiceReferenceWeight.WeightUnit inputUnit = (ServiceReferenceWeight.WeightUnit)Enum.Parse(typeof(ServiceReferenceWeight.WeightUnit), InputUnit.SelectedItem.ToString()),
                               outputUnit = (ServiceReferenceWeight.WeightUnit)Enum.Parse(typeof(ServiceReferenceWeight.WeightUnit), OutputUnit.SelectedItem.ToString());

                weightClient.ConvertWeightCompleted += weightClient_ConvertWeightCompleted;
                weightClient.ConvertWeightAsync(double.Parse(InputValue.Text), inputUnit, outputUnit);
            }
        }

        private void weightClient_ConvertWeightCompleted(object sender, ServiceReferenceWeight.ConvertWeightCompletedEventArgs e)
        {
            OutputValue.Text = e.Result.ToString();
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