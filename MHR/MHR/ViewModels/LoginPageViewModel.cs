using System;
using System.Threading.Tasks;
using MHR.Extension.Events;
using Xamarin.Forms;

namespace MHR.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        #region Attributes and Properties

        string _username;
        string _password;

        public string Username
        {
            get { return _username; }
            set { SetValue(ref _username, value); }
        }

        public string Password
        {
            get { return _password; }
            set { SetValue(ref _password, value); }
        }

        #endregion

        #region Events

        public event EventHandler<LoginEventArgs> LoginError;

        #endregion

        public async Task Login()
        {
            OnLoadingStarted(EventArgs.Empty);

            //Try to execut login request
            if(await App.LoginService.LoginAsync(Username, Password))
                Application.Current.MainPage = new MasterPage();
            else
            {
                LoginEventArgs e = new LoginEventArgs("Incorrect Username or Password");
                OnLoginError(e);
            }

            OnLoadingEnded(EventArgs.Empty);
        }

        protected virtual void OnLoginError(LoginEventArgs e)
        {
            LoginError?.Invoke(this, e);
        }
    }
}