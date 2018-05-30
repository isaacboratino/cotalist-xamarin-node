using AppCotacao.Data.Mocks;
using AppCotacao.Data.Repositories;
using AppCotacao.Data.ServicesRestfull;
using AppCotacao.Model;
using AppCotacao.Services.DependencyServices;
using AppCotacao.Services.Exceptions;
using AppCotacao.Services.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCotacao.ViewModels.Shared
{
    public class LoginViewModel : BaseViewModel
    {
        //public IUsuarioRepository DataStore;

        private IRestService<UsuarioModel> RestService { get; set; }
        public ObjectReturnRestService<UsuarioModel> ResponseViewModel { get; set; }
        public UsuarioModel UsuarioModel { get; set; }
        public Command LoginCommand { get; set; }

        public LoginViewModel() : this(new DependencyServiceWrapper())
        {
        }

        public LoginViewModel(IDependencyService dependencyService) : base(dependencyService)
        {
            //DataStore = _dependencyService.Get<IUsuarioRepository>() ?? new UsuarioMock();

            UsuarioModel = new UsuarioModel(App.CurrentTipoApp)
            {
                Email = "",
                Senha = ""
            };

            this.ResponseViewModel = new ObjectReturnRestService<UsuarioModel>();

            LoginCommand = new Command(async () => await ExecuteLoginCommand()); 
        }

        private async Task ExecuteLoginCommand()
        {
            IsLoading = true;
            App.IsUsuarioLogado = false;
            App.ApiToken = string.Empty;

            try
            {
                if (this.IsViewModelValid())
                {
                    Dictionary<string, string> dictionaryRegister = new Dictionary<string, string>();
                    dictionaryRegister.Add("tipoApp", App.CurrentTipoApp.ToString());
                    dictionaryRegister.Add("email", UsuarioModel.Email);
                    dictionaryRegister.Add("senha", UsuarioModel.Senha);

                    RestService = new UsuarioRestService("auth/login");
                    this.ResponseViewModel = RestService.GenericSend(dictionaryRegister).Result;

                    //UsuarioModel usuarioEncontrado = await DataStore.GetAsync((o) => o.Email.Equals(UsuarioModel.Email) && o.Senha.Equals(UsuarioModel.Senha));
                    //App.IsUsuarioLogado = usuarioEncontrado != null;
                }
                    
            }
            catch (InvalidViewModelException ex)
            {
                this.ResponseViewModel.HasError = true;
                this.ResponseViewModel.ErrorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                this.ResponseViewModel.HasError = true;
                this.ResponseViewModel.ErrorMessage = ex.Message;
            }
            finally
            {
                IsLoading = false;
            }
        }

        public bool IsViewModelValid()
        {
            if (string.IsNullOrEmpty(UsuarioModel.Email) || string.IsNullOrWhiteSpace(UsuarioModel.Email))
                throw new InvalidViewModelException("Email é obrigatório");

            if (ValidationsUtil.IsEmailValid(UsuarioModel.Email) == false)
                throw new InvalidViewModelException("Email não está em um formato correto");

            if (string.IsNullOrEmpty(UsuarioModel.Senha) || string.IsNullOrWhiteSpace(UsuarioModel.Senha))
                throw new InvalidViewModelException("Senha é obrigatória");

            return true;
        }
    }
}
