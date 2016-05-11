using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace localSetting
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ApplicationDataContainer localSetting;
        ObservableCollection<items> mySetting = new ObservableCollection<items>();
        public MainPage()
        {
            localSetting = ApplicationData.Current.LocalSettings;
            this.InitializeComponent();
            BindLlist();
            this.DataContext = mySetting;
        }



        private async void add_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(key.Text))
            {
                await new MessageDialog("请输入Key").ShowAsync();
            }
            else
            {
                localSetting.Values[key.Text] = value.Text;
                BindLlist();
            }
        }

        private async void show_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(selectValue.Text))
            {
                if (localSetting.Values.ContainsKey(selectValue.Text))
                    display.Text = localSetting.Values[selectValue.Text].ToString();
                else
                    await new MessageDialog("无此Key").ShowAsync();
            }
            else
            {
                await new MessageDialog("输入所要查看的key的值！！").ShowAsync();
            }
        }
        private void BindLlist()
        {
            mySetting.Clear();
            foreach (string key in localSetting.Values.Keys)
            {
                mySetting.Add(new items { St = key });
            }

        }

        private void fly(object sender, RightTappedRoutedEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            if (element != null)
                FlyoutBase.ShowAttachedFlyout(element);
        }

        private void allDisplay_Tapped(object sender, TappedRoutedEventArgs e)
        {


        }



        private async void uopdate_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(update_key.Text.ToString()))
            {
                localSetting.Values[update_key.Text] = update_value.Text.ToString();
            }
            else
                await new MessageDialog("输入要改的Key").ShowAsync();
        }

        private async void delete_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(update_key.Text))
            {
                if (localSetting.Values.ContainsKey(update_key.Text))
                {
                    localSetting.Values.Remove(update_key.Text);
                    BindLlist();
                }
           else
                {
                    await new MessageDialog("无此key").ShowAsync();
                }
            }
            else
            {

                await new MessageDialog("输入要删的Key").ShowAsync();
            }
        }

        //private void myList_Tapped(object sender, TappedRoutedEventArgs e)
        //{

        //    if ((sender as FrameworkElement) != null)
        //    {
        //        Flyout.ShowAttachedFlyout((sender as FrameworkElement));
        //    }
        //}
    }
}
