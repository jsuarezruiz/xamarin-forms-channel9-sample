using System;
using Xamarin.Forms;

namespace Channel9.Models
{
    public enum MenuItemType
    {
        Home,
        Featured,
        Fresh,
        MostViewed,
        TopRated,
        Shows,
        Series,
        Events,
        Tags,
        Downloads,
        MyQueue,
        Settings
    }

    public class MenuItem : BindableObject
    {
        private string _title;

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private MenuItemType _menuItemType;

        public MenuItemType MenuItemType
        {
            get
            {
                return _menuItemType;
            }

            set
            {
                _menuItemType = value;
                OnPropertyChanged();
            }
        }

        private Type _viewModelType;

        public Type ViewModelType
        {
            get
            {
                return _viewModelType;
            }

            set
            {
                _viewModelType = value;
                OnPropertyChanged();
            }
        }

        private bool _isEnabled;

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }

            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }
    }
}