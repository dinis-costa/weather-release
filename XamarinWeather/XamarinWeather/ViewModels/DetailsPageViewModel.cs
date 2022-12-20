using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using XamarinWeather.Models.DetailedForecast;
using XamarinWeather.Models;
using XamarinWeather.Services;

namespace XamarinWeather.ViewModels
{
	public class DetailsPageViewModel : ViewModelBase
	{
        #region Fields & Constructor
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private Forecast _forecast;
        private DetailedForecast _dForecast;

        public DetailsPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;

        }
        #endregion

        #region Properties
        public Forecast Forecast
        {
            get => _forecast;
            set => SetProperty(ref _forecast, value);
        }
        public DetailedForecast DetailedForecast
        {
            get => _dForecast;
            set => SetProperty(ref _dForecast, value);
        }

        #endregion

        #region Methods

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
            if (parameters.ContainsKey("item"))
            {
                Forecast = parameters.GetValue<Forecast>("item");
                GetDetailedForecast(Forecast.Coord.Lat, Forecast.Coord.Lon);
                Title = Forecast.Name;
            }
        }

        public async void GetDetailedForecast(double lat, double lon)
        {
            string url = $"http://api.openweathermap.org/data/2.5/forecast?lat={lat}&lon={lon}&appid={Constants.OpenWeatherMapAPIKey}&units=metric";
            Response response = await _apiService.GetObjectAsync<DetailedForecast>(url).ConfigureAwait(false);

            DetailedForecast = response.Result as DetailedForecast;
        }
        #endregion
    }
}
