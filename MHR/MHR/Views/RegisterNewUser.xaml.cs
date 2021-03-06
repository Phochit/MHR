using MHR.Extensions;
using MHR.ViewModels;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MHR.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterNewUser : ContentPage
	{
        RegisterNewUserViewModel _viewModel
        {
            get { return BindingContext as RegisterNewUserViewModel; }
            set { BindingContext = value; }
        }

		public RegisterNewUser ()
		{
            InitializeComponent();

            picker_role.ItemsSource = new List<string> { "ADMIN", "USER" };

            // setting BindingContext
            _viewModel = new RegisterNewUserViewModel();

            _viewModel.LoadingStartedEvent += (sender, e) => { loading_view.IsVisible = true; };
            _viewModel.LoadingEndedEvent += async (sender, e) => 
            {
                loading_view.IsVisible = false;
                await Navigation.PopAsync();
            };
        }

        async Task Save_User_Handler(object sender, EventArgs e)
        {
            if(!entry_password.Text.Equals(entry_password_confirm.Text))
            {
                CustomAlertPopUp popUp = new CustomAlertPopUp("Passwords do not match");
                await PopupNavigation.Instance.PushAsync(popUp);
            } else
                await _viewModel.AddUser();

        }

        void Data_Changed_Handler(object sender, EventArgs e)
        {
            button_save.IsEnabled = 
                !string.IsNullOrEmpty(entry_username.Text) && !string.IsNullOrEmpty(entry_name.Text) &&
                !string.IsNullOrEmpty(entry_lastname.Text) && !string.IsNullOrEmpty(entry_mail.Text) &&
                !string.IsNullOrEmpty(entry_password.Text) && !string.IsNullOrEmpty(entry_password_confirm.Text) &&
                picker_role.SelectedItem != null;
        }
    }
}