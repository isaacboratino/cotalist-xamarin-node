using AppCotacao.Data.Mocks;
using AppCotacao.Data.Repositories;
using AppCotacao.Model;
using AppCotacao.Services.DependencyServices;
using AppCotacao.Services.Exceptions;
using AppCotacao.ViewModels.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppCotacao.UnitTest
{
    [TestClass]
    public class LoginCadastroViewModelUnitTest
    {
        IDependencyService _dependencyService;
        LoginCadastroViewModel cadastroViewModel;
        LoginViewModel loginViewModel;

        public LoginCadastroViewModelUnitTest()
        {
            _dependencyService = new DependencyServiceStub();
            _dependencyService.Register<IUsuarioRepository>(new UsuarioMock());
            cadastroViewModel = new LoginCadastroViewModel(_dependencyService)
            {
                RepeticaoSenha = "87654321",
                UsuarioModel = {
                    Email = "isaac2@gmail.com",
                    Senha = "87654321",
                    PessoaJuridicaModel =
                    {
                        CNPJ = "12123123123412",
                        NomeFantasia = "Nome fantasia da empresa"
                    }
                }
            };

            loginViewModel = new LoginViewModel(_dependencyService)
            {
                UsuarioModel = cadastroViewModel.UsuarioModel
            };
        }

        /*
        [TestMethod]
        public void LoginCadastroViewModel_Testar_cadastro_login_sucesso()
        {
            loginViewModel.LoginCommand.Execute(null);
            Assert.AreEqual(false, true);
        }

        [TestMethod]
        public void LoginCadastroViewModel_Testar_login_novo_usuario_cadastrado()
        {
            loginViewModel.LoginCommand.Execute(null);
            Assert.AreEqual(loginViewModel.IsUsuarioLogado, true);
        }

        [TestMethod]
        public void LoginCadastroViewModel_Testar_validacao_tipo_aplicativo_invalid()
        {
            cadastroViewModel.UsuarioModel.TipoApp = 0;
            InvalidViewModelException ex = Assert.ThrowsException<InvalidViewModelException>(() => cadastroViewModel.IsViewModelValid());
            Assert.AreEqual("O tipo de aplicativo deve ser cliente ou fornecedor", ex.Message);
            cadastroViewModel.UsuarioModel.TipoApp = TipoAppModel.FORNECEDOR;
        }

        [TestMethod]
        public void LoginCadastroViewModel_Testar_validacao_cnpj_obrigatorio()
        {
            cadastroViewModel.UsuarioModel.PessoaJuridicaModel.CNPJ = "";
            InvalidViewModelException ex = Assert.ThrowsException<InvalidViewModelException>(() => cadastroViewModel.IsViewModelValid());
            Assert.AreEqual("Email não está em um formato correto", ex.Message);            
        }

        [TestMethod]
        public void LoginCadastroViewModel_Testar_validacao_cnpj_invalido()
        {
            cadastroViewModel.UsuarioModel.PessoaJuridicaModel.CNPJ = "12123123123412";
            InvalidViewModelException ex = Assert.ThrowsException<InvalidViewModelException>(() => cadastroViewModel.IsViewModelValid());
            Assert.AreEqual("CNPJ não está em um formato correto", ex.Message);
        }

        [TestMethod]
        public void LoginCadastroViewModel_Testar_nome_fantasia_obrigatorio()
        {
            cadastroViewModel.UsuarioModel.PessoaJuridicaModel.NomeFantasia = "";
            InvalidViewModelException ex = Assert.ThrowsException<InvalidViewModelException>(() => cadastroViewModel.IsViewModelValid());
            Assert.AreEqual("Nome fantasia é obrigatório", ex.Message);
            cadastroViewModel.UsuarioModel.PessoaJuridicaModel.NomeFantasia = "Nome fantasia";
        }

        [TestMethod]
        public void LoginCadastroViewModel_Testar_email_obrigatorio()
        {
            cadastroViewModel.UsuarioModel.Email = "";
            InvalidViewModelException ex = Assert.ThrowsException<InvalidViewModelException>(() => cadastroViewModel.IsViewModelValid());
            Assert.AreEqual("Email é obrigatório", ex.Message);
        }

        [TestMethod]
        public void LoginCadastroViewModel_Testar_validacao_email_com_formato_invalido()
        {
            cadastroViewModel.UsuarioModel.Email = "isaac_bla.com";
            InvalidViewModelException ex = Assert.ThrowsException<InvalidViewModelException>(() => cadastroViewModel.IsViewModelValid());
            Assert.AreEqual("Email não está em um formato correto", ex.Message);
            cadastroViewModel.UsuarioModel.Email = "isaac@gmail.com";
        }

        [TestMethod]
        public void LoginCadastroViewModel_Testar_validacao_senha_obrigatoria()
        {
            cadastroViewModel.UsuarioModel.Senha = "";
            InvalidViewModelException ex = Assert.ThrowsException<InvalidViewModelException>(() => cadastroViewModel.IsViewModelValid());
            Assert.AreEqual("Senha é obrigatória", ex.Message);
        }

        [TestMethod]
        public void LoginCadastroViewModel_Testar_validacao_senha_e_repeticao_senha_diferentes()
        {
            cadastroViewModel.UsuarioModel.Senha = "1234";
            cadastroViewModel.RepeticaoSenha = "1234";
            InvalidViewModelException ex = Assert.ThrowsException<InvalidViewModelException>(() => cadastroViewModel.IsViewModelValid());
            Assert.AreEqual("Senha e confirmação de senha devem ser iguais", ex.Message);
        }  
        */
    }
}
