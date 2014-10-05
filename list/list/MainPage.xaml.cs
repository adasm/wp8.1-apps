using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

namespace list
{
    public sealed partial class MainPage : Page
    {
        

        private void Remove(Track track)
        {
            Track.list.Remove(track);
            Refresh();
        }

        private void Refresh()
        {
            listBox.ItemsSource = null;
            listBox.ItemsSource = Track.list;
        }

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Refresh();
        }

        private void listBox_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateNew));
        }

        private async void Button_Click_Remove(object sender, RoutedEventArgs e)
        {
            Track track = (Track)listBox.SelectedItem;
            if(track != null)
            {
                var dialog = new MessageDialog("Track to be removed\n" + track);
                dialog.Title = "Are you sure?";
                dialog.Commands.Clear();
                dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
                dialog.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });
                var res = await dialog.ShowAsync();

                if ((int)res.Id == 0)
                {
                    Remove(track);
                }
            }
            
        }
    }
}
