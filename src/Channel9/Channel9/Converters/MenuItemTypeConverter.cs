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
                        return "Assets/channel9_home.png";
                    else
                        return "channel9_home";
                case MenuItemType.Featured:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/channel9-featured.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/channel9_featured.png";
                    else
                        return "channel9_featured";
                case MenuItemType.Fresh:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/channel9-fresh.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/channel9_fresh.png";
                    else
                        return "channel9_fresh";
                case MenuItemType.MostViewed:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/channel9-mostviewed.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/channel9_mostviewed.png";
                    else
                        return "channel9_mostviewed";
                case MenuItemType.TopRated:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/channel9-toprated.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/channel9_toprated.png";
                    else
                        return "channel9_toprated";
                case MenuItemType.Shows:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/channel9-shows.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/channel9_shows.png";
                    else
                        return "channel9_shows";
                case MenuItemType.Series:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/channel9-series.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/channel9_series.png";
                    else
                        return "channel9_series";
                case MenuItemType.Events:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/channel9-events.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/channel9_events.png";
                    else
                        return "channel9_events";
                case MenuItemType.Tags:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/channel9-tags.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/channel9_tags.png";
                    else
                        return "channel9_tags";
                case MenuItemType.Downloads:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/channel9_downloads.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/channel9_downloads.png";
                    else
                        return "channel9_downloads";
                case MenuItemType.MyQueue:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/channel9-myqueue.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/channel9_myqueue.png";
                    else
                        return "channel9_myqueue";
                case MenuItemType.Settings:
                    if (Device.RuntimePlatform == Device.GTK)
                        return "Images/channel9-settings.png";
                    else if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/channel9_settings.png";
                    else
                        return "channel9_settings";
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