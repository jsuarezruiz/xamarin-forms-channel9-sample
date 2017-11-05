using Channel9.Services.Navigation;
using Channel9.ViewModels.Base;
using System.Threading.Tasks;

namespace Channel9.ViewModels
{
    public class SplashViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public SplashViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override async Task InitializeAsync(object navigationData)
        {
            await _navigationService.NavigateToAsync<MainViewModel>();
        }
    }
}