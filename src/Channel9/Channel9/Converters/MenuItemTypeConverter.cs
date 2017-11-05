using Channel9.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace Channel9.Converters
{
    public class MenuItemTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var menuItemType = (MenuItemType)value;

            switch (menuItemType)
            {
                case MenuItemType.Home:
                    if(Device.RuntimePlatform == Device.GTK)
                        return "Images/channel9-home.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/channel9-home.png";
                    else
                        return "channel9-home";
                case MenuItemType.Featured:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/channel9-featured.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/channel9-featured.png";
                    else
                        return "channel9-featured";
                case MenuItemType.Fresh:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/channel9-fresh.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/channel9-fresh.png";
                    else
                        return "channel9-fresh";
                case MenuItemType.MostViewed:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/channel9-mostviewed.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/channel9-mostviewed.png";
                    else
                        return "channel9-mostviewed";
                case MenuItemType.TopRated:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/channel9-toprated.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/channel9-toprated.png";
                    else
                        return "channel9-toprated";
                case MenuItemType.Shows:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/channel9-shows.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/channel9-shows.png";
                    else
                        return "channel9-shows";
                case MenuItemType.Series:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/channel9-series.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/channel9-series.png";
                    else
                        return "channel9-series";
                case MenuItemType.Events:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/channel9-events.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/channel9-events.png";
                    else
                        return "channel9-events";
                case MenuItemType.Tags:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/channel9-tags.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/channel9-tags.png";
                    else
                        return "channel9-tags";
                case MenuItemType.Downloads:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/channel9-downloads.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/channel9-downloads.png";
                    else
                        return "channel9-downloads";
                case MenuItemType.MyQueue:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/channel9-myqueue.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/channel9-myqueue.png";
                    else
                        return "channel9-myqueue";
                case MenuItemType.Settings:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/channel9-settings.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/channel9-settings.png";
                    else
                        return "channel9-settings";
                default:
                    return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}