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
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel.Core;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace App1
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            var main = Window.Current.Content as MainPage;
            Frame.Navigate(typeof(Page2), this);
        }

        private async void HyperlinkButton_Click_1(object sender, RoutedEventArgs e)
        {
            var currentViewId = ApplicationView.GetForCurrentView().Id;
            await CoreApplication.CreateNewView().Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                var sub = Window.Current;
                var frame = new Frame();
                sub.Content = frame;
                frame.Navigate(typeof(SubWindowMainPage));
                sub.Activate();
                await ApplicationViewSwitcher.TryShowAsStandaloneAsync(
                    ApplicationView.GetApplicationViewIdForWindow(sub.CoreWindow),
                    ViewSizePreference.Default,
                    currentViewId,
                    ViewSizePreference.Default);
            });
        }
    }
}
