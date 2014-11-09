using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace geo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //var cul = "pl-PL";
            //var cultureInfo = new CultureInfo(cul);
            //CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            //Debug.WriteLine(CultureInfo.CurrentCulture.ToString());

        }

        private async void ButtonGPS_OnClick(object sender, RoutedEventArgs e)
        {
            var locator = new Geolocator();
            locator.DesiredAccuracyInMeters = 50;

            var position = await locator.GetGeopositionAsync();

            await Map.TrySetViewAsync(position.Coordinate.Point, 15D);

        }

        private async void ButtonFind_OnClick(object sender, RoutedEventArgs e)
        {
            var findDialog = new FindDialog();
            await findDialog.ShowAsync();
            if (findDialog.search)
            {
                var result = await MapLocationFinder.FindLocationsAsync(findDialog.location,  null, 3);

                if (result.Status == MapLocationFinderStatus.Success && result.Locations != null && result.Locations.Count > 0)
                {
                    await Map.TrySetViewAsync(result.Locations[0].Point, 12D);
                }
            }
        }
    }
}
