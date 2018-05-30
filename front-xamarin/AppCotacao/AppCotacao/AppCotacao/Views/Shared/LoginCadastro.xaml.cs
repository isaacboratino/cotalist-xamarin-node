using AppCotacao.Services.Utils;
using AppCotacao.ViewModels.Shared;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCotacao.Views.Shared
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginCadastro : ContentPage
	{
        LoginCadastroViewModel viewModel;

        public LoginCadastro()
		{
			InitializeComponent ();
            BindingContext = viewModel = new LoginCadastroViewModel();
        }

        public void entryCNPJTextChanged(object sender, EventArgs e)
        {
            var textChangedEventArgs = e as TextChangedEventArgs;

            if (textChangedEventArgs.NewTextValue != textChangedEventArgs.OldTextValue && textChangedEventArgs.OldTextValue != null)
            {
                var entry = (Entry)sender;
                entry.Text = MasksUtil.AddMaskCNPJ(viewModel.UsuarioModel.PessoaJuridicaModel.CNPJ);
            }
        }

        async void Cadastrar_Clicked(object sender, EventArgs e)
        {
            if (emailValidator.IsValid == null || 
                senhaValidator.IsValid == null ||
                confirmacaoSenhaValidator.IsValid == null ||
                cnpjValidator.IsValid == null || 
                requiredValidator.IsValid == null)
            {
                if (emailValidator.IsValid == null)
                    emailValidator.IsValid = false;

                if (senhaValidator.IsValid == null)
                    senhaValidator.IsValid = false;

                if (confirmacaoSenhaValidator.IsValid == null)
                    confirmacaoSenhaValidator.IsValid = false;

                if (cnpjValidator.IsValid == null)
                    cnpjValidator.IsValid = false;

                if (requiredValidator.IsValid == null)
                    requiredValidator.IsValid = false;
            }
            else if (!viewModel.UsuarioModel.Senha.Equals(viewModel.ConfirmacaoSenha))
            {
                await DisplayAlert("Atenção", "Senhas devem ser iguais", "Ok");
            }
            else if (emailValidator.IsValid.Value &&
                senhaValidator.IsValid.Value &&
                confirmacaoSenhaValidator.IsValid.Value &&
                cnpjValidator.IsValid.Value &&
                requiredValidator.IsValid.Value)
            {

                viewModel.IsLoading = true;
                viewModel.RegisterCommand.Execute(null);                

                if (viewModel.ResponseViewModel.IsSuccess)
                {
                    App.ApiToken = (string)viewModel.ResponseViewModel.JSonContent["token"];
                    App.IsUsuarioLogado = true;
                    await DisplayAlert("Sucesso", "Usuário registrado!", "Ok");                    
                    await Navigation.PushAsync(new MainAreaRestrita());
                }
                else
                {
                    await DisplayAlert("Atenção", viewModel.ResponseViewModel.ErrorMessage, "Ok");
                }
            }
            else
            {
                await DisplayAlert("Atenção", "Os campos devem ser preenchidos corretamente", "Ok");
            }
        }
    }
}