using AppCotacao.Data.ServicesRestfull;
using AppCotacao.Model;
using AppCotacao.Services.DependencyServices;
using AppCotacao.Services.Exceptions;
using AppCotacao.Services.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCotacao.ViewModels.Shared
{
    public class LoginCadastroViewModel : BaseViewModel
    {        
        //private IUsuarioRepository DataStore { get; set; }
        private IRestService<UsuarioModel> RestService { get; set; }
        public ObjectReturnRestService<UsuarioModel> ResponseViewModel { get; set; }
        public UsuarioModel UsuarioModel { get; set; }
        public Command RegisterCommand { get; set; }
        public string ConfirmacaoSenha { get; set; }
        
        public LoginCadastroViewModel() : this(new DependencyServiceWrapper())
        {
        }

        public LoginCadastroViewModel(IDependencyService dependencyService) : base(dependencyService)
        {
            //DataStore = _dependencyService.Get<IUsuarioRepository>() ?? new UsuarioMock();
            
            ConfirmacaoSenha = "";
            UsuarioModel = new UsuarioModel(App.CurrentTipoApp)
            {
                Email = "",
                Senha = "",
                PessoaJuridicaModel = new PessoaJuridicaModel()
                {
                    CNPJ = "",
                    RazaoSocial = ""
                }
            };

            this.ResponseViewModel = new ObjectReturnRestService<UsuarioModel>();

            RegisterCommand = new Command(async () => await ExecuteRegisterCommand()); 
        }

        private async Task ExecuteRegisterCommand()
    {
            //if (IsBusy)
            //    return;

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
                    dictionaryRegister.Add("confirmacaoSenha", ConfirmacaoSenha);
                    dictionaryRegister.Add("cnpj", UsuarioModel.PessoaJuridicaModel.CNPJ);
                    dictionaryRegister.Add("razaoSocial", UsuarioModel.PessoaJuridicaModel.RazaoSocial);

                    RestService = new UsuarioRestService("auth/register");
                    this.ResponseViewModel = RestService.GenericSend(dictionaryRegister).Result;                    
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
            if (UsuarioModel.TipoApp != TipoAppModel.CLIENTE && UsuarioModel.TipoApp != TipoAppModel.FORNECEDOR)
                throw new InvalidViewModelException("O tipo de aplicativo deve ser cliente ou fornecedor");

            if (string.IsNullOrEmpty(UsuarioModel.PessoaJuridicaModel.CNPJ)
             || string.IsNullOrWhiteSpace(UsuarioModel.PessoaJuridicaModel.CNPJ))
                throw new InvalidViewModelException("CNPJ é obrigatório");

            if (ValidationsUtil.IsCNPJValid(UsuarioModel.PessoaJuridicaModel.CNPJ) == false)
                throw new InvalidViewModelException("CNPJ não está em um formato correto");

            if (string.IsNullOrEmpty(UsuarioModel.PessoaJuridicaModel.RazaoSocial)
             || string.IsNullOrWhiteSpace(UsuarioModel.PessoaJuridicaModel.RazaoSocial))
                throw new InvalidViewModelException("Nome fantasia é obrigatório");

            if (string.IsNullOrEmpty(UsuarioModel.Email) || string.IsNullOrWhiteSpace(UsuarioModel.Email))
                throw new InvalidViewModelException("Email é obrigatório");

            if (ValidationsUtil.IsEmailValid(UsuarioModel.Email) == false)
                throw new InvalidViewModelException("Email não está em um formato correto");

            if (string.IsNullOrEmpty(UsuarioModel.Senha) || string.IsNullOrWhiteSpace(UsuarioModel.Senha))
                throw new InvalidViewModelException("Senha é obrigatória");            

            if (UsuarioModel.Senha.Equals(ConfirmacaoSenha) == false)
                throw new InvalidViewModelException("Senha e confirmação de senha devem ser iguais");

            return true;
        }
    }
}
