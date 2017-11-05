using Channel9.Services.Navigation;
using Channel9.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Channel9.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private ObservableCollection<Models.MenuItem> _menuItems;

        private INavigationService _navigationService;

        public MenuViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ObservableCollection<Models.MenuItem> MenuItems
        {
            get
            {
                return _menuItems;
            }
            set
            {
                _menuItems = value;
                OnPropertyChanged();
            }
        }

        public ICommand ItemSelectedCommand => new Command<Models.MenuItem>(SelectMenuItem);

        public override Task InitializeAsync(object navigationData)
        {
            InitMenuItems();

            return base.InitializeAsync(navigationData);
        }

        private void InitMenuItems()
        {
            MenuItems = new ObservableCollection<Models.MenuItem>
            {
                new Models.MenuItem
                {
                    Title = "Home",
                    MenuItemType = Models.MenuItemType.Home,
                    ViewModelType = typeof(HomeViewModel),
                    IsEnabled = true
                },
                new Models.MenuItem
                {
                    Title = "Featured",
                    MenuItemType = Models.MenuItemType.Featured,
                    IsEnabled = false
                },
                new Models.MenuItem
                {
                    Title = "Fresh",
                    MenuItemType = Models.MenuItemType.Fresh,
                    IsEnabled = false
                },
                new Models.MenuItem
                {
                    Title = "Most Viewed",
                    MenuItemType = Models.MenuItemType.MostViewed,
                    IsEnabled = false
                },
                new Models.MenuItem
                {
                    Title = "Top Rated",
                    MenuItemType = Models.MenuItemType.TopRated,
                    IsEnabled = false
                },
                new Models.MenuItem
                {
                    Title = "Shows",
                    MenuItemType = Models.MenuItemType.Shows,
                    IsEnabled = false
                },
                new Models.MenuItem
                {
                    Title = "Series",
                    MenuItemType = Models.MenuItemType.Series,
                    IsEnabled = false
                },
                new Models.MenuItem
                {
                    Title = "Events",
                    MenuItemType = Models.MenuItemType.Events,
                    IsEnabled = false
                },
                new Models.MenuItem
                {
                    Title = "Tags",
                    MenuItemType = Models.MenuItemType.Tags,
                    IsEnabled = false
                },
                new Models.MenuItem
                {
                    Title = "Downloads",
                    MenuItemType = Models.MenuItemType.Downloads,
                    IsEnabled = false
                },
                new Models.MenuItem
                {
                    Title = "My Queue",
                    MenuItemType = Models.MenuItemType.MyQueue,
                    IsEnabled = false
                },
                new Models.MenuItem
                {
                    Title = "Settings",
                    MenuItemType = Models.MenuItemType.Settings,
                    IsEnabled = false
                }
            };
        }

        private async void SelectMenuItem(Models.MenuItem item)
        {
            if (item.IsEnabled)
            {
                await _navigationService.NavigateToAsync(item.ViewModelType, null);
            }
        }
    }
}