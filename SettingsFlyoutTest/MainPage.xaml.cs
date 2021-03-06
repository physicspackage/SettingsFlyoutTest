﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ApplicationSettings;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using WindowsStore.FalafelUtility;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SettingsFlyoutTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SettingsFlyoutInfoCollection collection = new SettingsFlyoutInfoCollection();
            collection.PopupChanged += collection_PopupChanged;
            collection.AddSettingsFlyoutInfo(typeof(SettingsFlyout), "FlyoutTestID", "Flyout Test", 500);
            SettingsFlyoutAttachedProperty.SetValue(this, collection);
        }

        void collection_PopupChanged(object sender, bool e)
        {
            if (e)
            {
                ad1.Suspend();
            }
            else
            {
                ad1.Resume();
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            SettingsFlyoutAttachedProperty.SetValue(this, null);
        }
    }
}
