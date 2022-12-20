using Prism.Commands;
using Prism.Navigation;
using XamarinWeather.Models;
using XamarinWeather.Views;

namespace XamarinWeather.ItemViewModels
{
    public class ForecastItemViewModel : Forecast
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectItemCommand;
        public ForecastItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectItemCommand =>
            _selectItemCommand ??
            (_selectItemCommand = new DelegateCommand(SelectItemAsync));

        private async void SelectItemAsync()
        {
            try
            {
                NavigationParameters parameters = new NavigationParameters
                {
                    {"item", this}
                };

                await _navigationService.NavigateAsync(nameof(DetailsPage), parameters);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
