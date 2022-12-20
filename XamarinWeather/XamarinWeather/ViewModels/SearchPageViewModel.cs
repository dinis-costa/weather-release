using Firebase.Auth;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinWeather.ItemViewModels;
using XamarinWeather.Models;
using XamarinWeather.Services;
using XamarinWeather.Views;

namespace XamarinWeather.ViewModels
{
    public class SearchPageViewModel : ViewModelBase
    {
        #region Fields & Constructor
        private string _query;
        private bool _isLoading;
        private bool _isEnabled;
        private DelegateCommand _searchCommand;
        private readonly IApiService _apiService;
        private ObservableCollection<ForecastItemViewModel> _forecastList;
        private readonly INavigationService _navigation;

        public SearchPageViewModel(
            INavigationService navigationService,
            IApiService apiService)
            : base(navigationService)
        {
            _navigation = navigationService;
            _apiService = apiService;

            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(Constants.FirebaseWebApiKey));
            var savedAuth = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("Token", ""));
            Title = savedAuth.User.Email;

            IsEnabled = true;
        }
        #endregion

        #region Properties
        public ObservableCollection<ForecastItemViewModel> ForecastList
        {
            get => _forecastList;
            set => SetProperty(ref _forecastList, value);
        }
        public string Query
        {
            get => _query;
            set => SetProperty(ref _query, value);
        }
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }
        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        #endregion

        #region Methods

        

        public DelegateCommand SearchCommand => _searchCommand
            ?? (_searchCommand = new DelegateCommand(Search));

        private async Task<Forecast> LoadForecastAsync(double lat, double lon)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={Constants.OpenWeatherMapAPIKey}&units=metric";
            Response response = await _apiService.GetObjectAsync<Forecast>(url);

            return (Forecast)response.Result;
        }

        private async void Search()
        {

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert(
                        "Error!",
                        "No Internet connection.",
                        "OK");
                });
                return;
            }

            if (string.IsNullOrEmpty(Query))
                return;


            IsLoading = true;
            if (ForecastList != null)
            {
                ForecastList.Clear();
            }

            string url = $"http://api.openweathermap.org/geo/1.0/direct?q={Query}&limit=5&appid={Constants.OpenWeatherMapAPIKey}&units=metric";
            Response response = await _apiService.GetListAsync<City>(url);

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error!", response.Message, "OK");
                return;
            }

            List<City> cities = (List<City>)response.Result;

            ObservableCollection<Forecast> forecasts = new ObservableCollection<Forecast>();

            foreach (var item in cities)
            {
                var entry = await LoadForecastAsync(item.Lat, item.Lon).ConfigureAwait(false);
                forecasts.Add(entry);
            }

            ForecastList = new ObservableCollection<ForecastItemViewModel>(
                forecasts.Select(f => new ForecastItemViewModel(_navigation)
                {
                    Dt = f.Dt,
                    Name = f.Name,
                    Main = f.Main,
                    Clouds = f.Clouds,
                    Wind = f.Wind,
                    Sys = f.Sys,
                    Coord = f.Coord,
                    Weather = f.Weather,
                    Base = f.Base,
                    Visibility = f.Visibility,
                    Cod = f.Cod,
                    Id = f.Id,
                    Timezone = f.Timezone,
                }));

            IsLoading = false;
        }
        #endregion


    }
}
