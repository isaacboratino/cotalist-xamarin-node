using AppCotacao.ViewModels.Shared;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCotacao.Views.Shared
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
        LoginViewModel viewModel;

        public Login ()
		{
			InitializeComponent ();
            BindingContext = viewModel =  new LoginViewModel();
        }

        async void Entrar_Clicked(object sender, EventArgs e)
        {
            if (emailValidator.IsValid == null || senhaValidator.IsValid == null) {
                if (emailValidator.IsValid == null)
                    emailValidator.IsValid = false;

                if (senhaValidator.IsValid == null)
                    senhaValidator.IsValid = false;
            }
            else if (emailValidator.IsValid.Value && senhaValidator.IsValid.Value)
            {               
                viewModel.LoginCommand.Execute(null);

                if (viewModel.ResponseViewModel.IsSuccess)
                {
                    App.ApiToken = (string)viewModel.ResponseViewModel.JSonContent["token"];
                    App.IsUsuarioLogado = true;
                    //await DisplayAlert("Sucesso", "Usuário registrado!", "Ok");
                    await Navigation.PushAsync(new MainAreaRestrita());
                }
                else
                {              
                    await DisplayAlert("Atenção", viewModel.ResponseViewModel.ErrorMessage, "Ok");
                }
            }
            else
            {
                await DisplayAlert("Atenção", "Usuário e senha não são válidos", "Ok");
            }            
        }

        async void Cadastrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginCadastro());
        }
    }
}