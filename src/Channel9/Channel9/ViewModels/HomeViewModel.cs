using System.Threading.Tasks;
using Channel9.Services.RssService;
using Channel9.ViewModels.Base;
using Channel9.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Channel9.Services.Navigation;
using System.Diagnostics;

namespace Channel9.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private Episode _banner;
        private ObservableCollection<Episode> _channel9;
        private ObservableCollection<Episode> _xamarinShow;
        private ObservableCollection<Episode> _build;

        private readonly INavigationService _navigationService;
        private readonly IRssService _rssService;

        public HomeViewModel(
            INavigationService navigationService,
            IRssService rssService)
        {
            _navigationService = navigationService;
            _rssService = rssService;
        }

        public Episode Banner
        {
            get { return _banner; }
            set
            {
                _banner = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Episode> Channel9
        {
            get { return _channel9; }
            set
            {
                _channel9 = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Episode> XamarinShow
        {
            get { return _xamarinShow; }
            set
            {
                _xamarinShow = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Episode> Build
        {
            get { return _build; }
            set
            {
                _build = value;
                OnPropertyChanged();
            }
        }

        public ICommand PlayerCommand => new Command<Episode>(PlayerAsync);

        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;

            var channel9 = await _rssService.GetEpisodesAsync(AppSettings.Channel9, "Channel 9");
            Channel9 = new ObservableCollection<Episode>(channel9.Take(10));
            Banner = Channel9.FirstOrDefault();

            var xamarinShow = await _rssService.GetEpisodesAsync(AppSettings.XamarinShow, "Xamarin Show");
            XamarinShow = new ObservableCollection<Episode>(xamarinShow.Take(10));

            var build = await _rssService.GetEpisodesAsync(AppSettings.Build2017, "Build 2017");
            Build = new ObservableCollection<Episode>(build.Take(10));

            IsBusy = false;
        }

        private void PlayerAsync(object obj)
        {
            var episode = obj as Episode;

            if (episode != null)
            {
                Debug.WriteLine(episode.Title);

                // TODO: Navigate to detail
            }
        }
    }
}
