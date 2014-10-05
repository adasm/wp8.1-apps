using list.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
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
    public sealed partial class CreateNew : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public CreateNew()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            
        }

        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        private void Save(Track track)
        {
            Track.list.Add(track);
            if (NavigationHelper.CanGoBack())
                NavigationHelper.GoBack();
        }

        private async void Button_Click_Create(object sender, RoutedEventArgs e)
        {
           if(artist.Text.Length > 0 && album.Text.Length > 0 && track.Text.Length > 0)
           {
               Save(new Track { artist = artist.Text, album = album.Text, trackName = track.Text });
           }
           else
           {
               var dialog = new MessageDialog("Artist, Album or Track text box is empty");
               dialog.Title = "Cannot Add New Track";
               var res = await dialog.ShowAsync();
           }
        }

        private async void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            if (NavigationHelper.CanGoBack())
                NavigationHelper.GoBack();
        }

        #region NavigationHelper registration

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion
    }
}
