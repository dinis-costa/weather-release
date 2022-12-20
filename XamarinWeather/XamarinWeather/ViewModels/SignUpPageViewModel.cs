using Firebase.Auth;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XamarinWeather.Validators;
using XamarinWeather.Validators.Rules;

namespace XamarinWeather.ViewModels
{
    [Preserve(AllMembers = true)]
    public class SignUpPageViewModel : LoginViewModel
    {
        #region Constructor

        public SignUpPageViewModel()
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

        private ValidatablePair<string> password;
        public ValidatablePair<string> Password
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
        #endregion

        #region Methods

        public bool AreFieldsValid()
        {
            bool isEmail = this.Email.Validate();
            bool isPasswordValid = this.Password.Validate();
            return isPasswordValid && isEmail;
        }

        private void InitializeProperties()
        {
            this.Password = new ValidatablePair<string>();
        }

        private void AddValidationRules()
        {
            this.Password.Item1.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password Required" });
            this.Password.Item2.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Re-enter Password" });
        }

        private async void LoginClicked(object obj)
        {
            await App.Current.MainPage.Navigation.PopToRootAsync();
        }

        private async void SignUpClicked(object obj)
        {
            if (this.AreFieldsValid())
            {
                try
                {
                    IsLoading = true;

                    var authProvider = new FirebaseAuthProvider(new FirebaseConfig(Constants.FirebaseWebApiKey));
                    var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(this.Email.Value, this.Password.Item1.Value);
                    string getToken = auth.FirebaseToken;

                    IsLoading = false;

                    await App.Current.MainPage.Navigation.PopToRootAsync();
                    await App.Current.MainPage.DisplayAlert("Success!", "You can now login.", "OK");

                }
                catch (Exception ex)
                {
                    IsLoading = false;
                    await App.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
                }
            }
        }

        #endregion
    }
}