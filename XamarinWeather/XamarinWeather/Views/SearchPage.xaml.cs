using Prism.Navigation;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinWeather.Views
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        public async void OnItemClicked(object sender, EventArgs e)
        {
            ToolbarItem item = (ToolbarItem)sender;

            switch (item.Text)
            {
                case "Saved":
                    await App.Current.MainPage.DisplayAlert("Alert!", $"You clicked on {item.Text}.", "OK");
                    break;
                case "Settings":
                    await App.Current.MainPage.DisplayAlert("Alert!", $"You clicked on {item.Text}.", "OK");
                    break;
                case "About":
                    await App.Current.MainPage.Navigation.PushAsync(new AboutPage());
                    break;
                case "Logout":
                    await App.Current.MainPage.Navigation.PopToRootAsync();
                    break;
            }
        }
    }
}
