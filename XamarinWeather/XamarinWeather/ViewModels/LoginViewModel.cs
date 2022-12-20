using Xamarin.Forms.Internals;
using XamarinWeather.Validators;
using XamarinWeather.Validators.Rules;

namespace XamarinWeather.ViewModels
{
    /// <summary>
    /// ViewModel for login page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class LoginViewModel : BaseViewModel
    {
        #region Fields & Constructor

        private ValidatableObject<string> email;

        public LoginViewModel()
        {
            this.InitializeProperties();
            this.AddValidationRules();
        }

        #endregion

        #region Property

        public ValidatableObject<string> Email
        {
            get
            {
                return this.email;
            }

            set
            {
                if (this.email == value)
                {
                    return;
                }

                this.SetProperty(ref this.email, value);
            }
        }
        #endregion

        #region Methods

        public bool IsEmailFieldValid()
        {
            bool isEmailValid = this.Email.Validate();
            return isEmailValid;
        }

        private void InitializeProperties()
        {
            this.Email = new ValidatableObject<string>();
        }

        private void AddValidationRules()
        {
            this.Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email Required" });
            this.Email.Validations.Add(new IsValidEmailRule<string> { ValidationMessage = "Invalid Email" });
        }

        #endregion
    }
}
