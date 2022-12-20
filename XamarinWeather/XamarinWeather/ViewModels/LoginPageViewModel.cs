using Firebase.Auth;
using Newtonsoft.Json;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XamarinWeather.Validators;
using XamarinWeather.Validators.Rules;
using XamarinWeather.Views;

namespace XamarinWeather.ViewModels
{
    /// <summary>
    /// ViewModel for login page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class LoginPageViewModel : LoginViewModel
    {
        #region Fields & Constructor

        public LoginPageViewModel()
        {
            this.InitializeProperties();
            this.AddValidationRules();
            this.LoginCommand = new Command(this.LoginClicked);
            this.SignUpCommand = new Command(this.SignUpClicked);
        }

        #endregion

        #region Properties

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        private ValidatableObject<string> password;
        public ValidatableObject<string> Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (this.password == value)
                {
                    return;
                }

                this.SetProperty(ref this.password, value);
            }
        }

        #endregion

        #region Command

        public Command LoginCommand { get; set; }

        public Command SignUpCommand { get; set; }

        public Command ForgotPasswordCommand { get; set; }

        #endregion

        #region Methods

        public bool AreFieldsValid()
        {
            bool isEmailValid = this.Email.Validate();
            bool isPasswordValid = this.Password.Validate();
            return isEmailValid && isPasswordValid;
        }

        private void InitializeProperties()
        {
            this.Password = new ValidatableObject<string>();
        }

        private void AddValidationRules()
        {
            this.Password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password Required" });
        }

        private async void LoginClicked(object obj)
        {
            if (this.AreFieldsValid())
            {
                try
                {
                    IsLoading = true;

                    var authProvider = new FirebaseAuthProvider(new FirebaseConfig(Constants.FirebaseWebApiKey));
                    var auth = await authProvider.SignInWithEmailAndPasswordAsync(this.Email.Value, this.Password.Value);
                    var content = await auth.GetFreshAuthAsync();
                    var serializedContent = JsonConvert.SerializeObject(content);
                    Preferences.Set("Token", serializedContent);

                    IsLoading = false;

                    await App.Current.MainPage.Navigation.PushAsync(new SearchPage());
                }
                catch (Exception ex)
                {

                    IsLoading = false;
                    await App.Current.MainPage.DisplayAlert("Error!", "Unable to login. Confirm your credentials and network availability.", "OK");
                }
            }
        }

        private async void SignUpClicked(object obj)
        {
            await App.Current.MainPage.Navigation.PushAsync(new SignUpPage());
        }


        #endregion
    }
}