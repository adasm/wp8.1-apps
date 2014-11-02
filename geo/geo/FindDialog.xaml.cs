﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers.Provider;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace geo
{
    public sealed partial class FindDialog : ContentDialog
    {
        public bool search = false;
        public string location = null;

        public FindDialog()
        {
            this.InitializeComponent();

            //var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            //Title = loader.GetString("search");
            //PrimaryButtonText = loader.GetString("search");
            //SecondaryButtonText = loader.GetString("cancel");
            //Location.Header = loader.GetString("location");
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            search = true;
            location = Location.Text;
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            
        }
    }
}
